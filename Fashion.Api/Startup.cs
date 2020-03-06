using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Fashion.Api.Auth;
using Fashion.Api.Filter;
using Fashion.Api.Setup;
using Fashion.Common;
using Fashion.Common.DB;
using Fashion.Common.Helper;
using Fashion.Common.Logger;
using Fashion.Model.Auth;
using log4net;
using log4net.Config;
using log4net.Repository;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Api
{
	public class Startup
	{
		/// <summary>
		/// log4net 仓储库
		/// </summary>
		public static ILoggerRepository Repository { get; set; }
		private static readonly ILog log = LogManager.GetLogger(typeof(GlobalExceptionsFilter));
		public IConfiguration Configuration { get; }
		public IHostingEnvironment Env { get; }

		public Startup(IConfiguration configuration, IHostingEnvironment env)
		{
			Configuration = configuration;
			Env = env;
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{	
			services.AddSingleton(new AppSettingsHelper(Env));
			services.AddDbSetup();
			services.AddAutoMapperSetup();
			services.AddSqlsugarSetup();
			services.AddCorsSetup();
			services.AddSwaggerSetup();
			services.AddHttpContextSetup();
			services.AddAuthorizationSetup();

			// log日志注入
			services.AddSingleton<ILoggerHelper, LoggerHelper>();

			#region MVC + GlobalExceptions

			//注入全局异常捕获
			services.AddMvc(o =>
			{
				// 全局异常过滤
				o.Filters.Add(typeof(GlobalExceptionsFilter));
			})
			.AddJsonOptions(options =>
			{
				// 忽略循环引用
				options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
				// 不使用驼峰
				options.SerializerSettings.ContractResolver = new DefaultContractResolver();
				// 设置时间格式
				options.SerializerSettings.DateFormatString = "yyyy-MM-dd HH:mm:ss";
				// 如字段为null值，该字段不会返回到前端
				// options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
			})
			.SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

			#endregion

			#region AutoFac 注入
			var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
			//实例化 AutoFac  容器   
			var builder = new ContainerBuilder();

			//将services填充到Autofac容器生成器中
			var servicesDllFile = Path.Combine(basePath, "Fashion.Services.dll");
			var assemblysServices = Assembly.LoadFrom(servicesDllFile);
			builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces();//指定已扫描程序集中的类型注册为提供所有其实现的接口。

			//将Repository填充到Autofac容器生成器中
			var repositoryDllFile = Path.Combine(basePath, "Fashion.Repository.dll");
			var assemblysRepository = Assembly.LoadFrom(repositoryDllFile);
			builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();

			builder.Populate(services);

			//使用已进行的组件登记创建新容器
			var ApplicationContainer = builder.Build();

			#endregion

			return new AutofacServiceProvider(ApplicationContainer);//第三方IOC接管 core内置DI容器
		}

		public void ConfigureContainer(ContainerBuilder builder)
		{
			
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{       
			string ApiName = "Fashion.Api";
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}

			#region Swagger
			app.UseSwagger();
			app.UseSwaggerUI(c =>
			{
				c.SwaggerEndpoint($"/swagger/v1/swagger.json", $"{ApiName} v1");//注意这个 v1 要和上边 ConfigureServices 中配置的大小写一致
																				// 将swagger设置成首页
				c.RoutePrefix = ""; //路径配置，设置为空，表示直接在根域名（localhost:8001）访问该文件,注意localhost:8001/swagger是访问不到的，去launchSettings.json把launchUrl去掉
			});
			#endregion

			//开启认证
			app.UseAuthentication();

			app.UseMvc();
		}
	}
}
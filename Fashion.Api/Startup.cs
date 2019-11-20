using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Fashion.Api.Auth;
using Fashion.Api.Filter;
using Fashion.Common.DB;
using Fashion.Common.Helper;
using Fashion.Common.Log;
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
		public IConfiguration Configuration { get; }
		public IHostingEnvironment Env { get; }
		private const string ApiName = "Fashion.Api"; 

		public Startup(IConfiguration configuration, IHostingEnvironment env)
		{
			Configuration = configuration;
			Env = env;
			//log4net
			Repository = LogManager.CreateRepository(Configuration["Logging:Log4Net:Name"]);
			//指定配置文件，如果这里你遇到问题，应该是使用了InProcess模式，请查看 .csproj,并删之
			var contentPath = env.ContentRootPath;
			var log4Config = Path.Combine(contentPath, "log4net.config");
			XmlConfigurator.Configure(Repository, new FileInfo(log4Config));
		}

		// This method gets called by the runtime. Use this method to add services to the container.
		public IServiceProvider ConfigureServices(IServiceCollection services)
		{
			var basePath = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;

			#region 初始化DB
			services.AddScoped<Fashion.Api.Seed.DBSeed>();
			services.AddScoped<Fashion.Api.Seed.MyContext>();
			#endregion

			#region Automapper
			services.AddAutoMapper(typeof(Startup));
			#endregion

			#region Swagger
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info
				{
					Version = "v0.1.0",
					Title = "Fashion API",
					Description = "框架说明文档",
					TermsOfService = "None",
					Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Name = "Fashion", Email = "Fashion@xxx.com", Url = "https://www.jianshu.com/u/94102b59cc2a" }
				});

				//就是这里

				#region 读取xml信息
				var xmlPath = Path.Combine(basePath, "Fashion.Api.xml");//这个就是刚刚配置的xml文件名
				var xmlModelPath = Path.Combine(basePath, "Fashion.Model.xml");//这个就是Model层的xml文件名
				c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改
				c.IncludeXmlComments(xmlModelPath);
				#endregion

				#region Token绑定到ConfigureServices
				//添加header验证信息
				//c.OperationFilter<SwaggerHeader>();
				var security = new Dictionary<string, IEnumerable<string>> { { "Fashion.Api", new string[] { } }, };
				c.AddSecurityRequirement(security);
				//方案名称“Fashion.Api”可自定义，上下一致即可
				c.AddSecurityDefinition("Fashion.Api", new ApiKeyScheme
				{
					Description = "JWT授权(数据将在请求头中进行传输) 直接在下框中输入Bearer {token}（注意两者之间是一个空格）\"",
					Name = "Authorization",//jwt默认的参数名称
					In = "header",//jwt默认存放Authorization信息的位置(请求头中)
					Type = "apiKey"
				});
				#endregion


			});
			#endregion

			//添加cors 服务
			services.AddCors(options => options
			.AddPolicy("cors", p => p.WithOrigins("http://localhost:2364")
			 .AllowAnyMethod().AllowAnyHeader()));

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

			#region jwt认证
			//读取配置文件
			var audienceConfig = Configuration.GetSection("Audience");
			var symmetricKeyAsBase64 = audienceConfig["Secret"];
			var keyByteArray = Encoding.ASCII.GetBytes(symmetricKeyAsBase64);
			var signingKey = new SymmetricSecurityKey(keyByteArray);
			var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);

			// 令牌验证参数
			var tokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuerSigningKey = true,
				IssuerSigningKey = signingKey,
				ValidateIssuer = true,
				ValidIssuer = audienceConfig["Issuer"],//发行人
				ValidateAudience = true,
				ValidAudience = audienceConfig["Audience"],//订阅人
				ValidateLifetime = true,
				ClockSkew = TimeSpan.FromSeconds(30),
				RequireExpirationTime = true,
			};

			//2.1【认证】、core自带官方JWT认证
			services.AddAuthentication(x =>
			{
				x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			})
			 .AddJwtBearer(o =>
			 {
				 o.TokenValidationParameters = tokenValidationParameters;
				 o.Events = new JwtBearerEvents
				 {
					 OnAuthenticationFailed = context =>
					 {
						 // 如果过期，则把<是否过期>添加到，返回头信息中
						 if (context.Exception.GetType() == typeof(SecurityTokenExpiredException))
						 {
							 context.Response.Headers.Add("Token-Expired", "true");
						 }
						 return Task.CompletedTask;
					 }
				 };
			 });
			#endregion

			#region 【3、复杂策略授权】

			#region 【授权】

			// 如果要数据库动态绑定，这里先留个空，后边处理器里动态赋值
			var permission = new List<PermissionItem>();

			// 角色与接口的权限要求参数
			var permissionRequirement = new PermissionRequirement(
				"/api/denied",// 拒绝授权的跳转地址（目前无用）
				permission,
				ClaimTypes.Role,//基于角色的授权
				audienceConfig["Issuer"],//发行人
				audienceConfig["Audience"],//听众
				signingCredentials,//签名凭据
				expiration: TimeSpan.FromSeconds(60 * 60)//接口的过期时间
				);
			#endregion

			services.AddAuthorization(options =>
			{
				options.AddPolicy(Permissions.Name,
						 policy => policy.Requirements.Add(permissionRequirement));
			});
			#endregion

			// 这里我不是引用了命名空间，因为如果引用命名空间的话，会和Microsoft的一个GetTypeInfo存在二义性，所以就直接这么使用了。
			services.AddScoped<SqlSugar.ISqlSugarClient>(o =>
			{
				return new SqlSugar.SqlSugarClient(new SqlSugar.ConnectionConfig()
				{
					ConnectionString = BaseDBConfig.ConnectionString,//必填, 数据库连接字符串
					DbType = (SqlSugar.DbType)BaseDBConfig.DbType,//必填, 数据库类型
					IsAutoCloseConnection = true,//默认false, 时候知道关闭数据库连接, 设置为true无需使用using或者Close操作
					InitKeyType = SqlSugar.InitKeyType.SystemTable//默认SystemTable, 字段信息读取, 如：该属性是不是主键，标识列等等信息
				});
			});

			//AppSettingsHelper注入
			services.AddSingleton(new AppSettingsHelper(Env));
			//services.AddSingleton(new LogLock(Env));

			// 注入权限处理器
			services.AddSingleton<IAuthorizationHandler, PermissionHandler>();
			services.AddSingleton(permissionRequirement);

			#region AutoFac 注入
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

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
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
using Fashion.Api.Filter;
using Fashion.Common;
using log4net;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Fashion.Api.Setup
{
	/// <summary>
	/// Swagger设置
	/// </summary>
	public static class SwaggerSetup
	{
		private static readonly ILog log = LogManager.GetLogger(typeof(GlobalExceptionsFilter));

		public static void AddSwaggerSetup(this IServiceCollection services)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));

			var basePath = AppContext.BaseDirectory;
			//var basePath2 = Microsoft.DotNet.PlatformAbstractions.ApplicationEnvironment.ApplicationBasePath;
			var ApiName = AppSettingsHelper.app(new string[] { "ApiName" });

			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new Info
				{
					Version = "v0.1.0",
					Title = $"{ApiName} 接口文档",
					Description = "框架说明文档",
					TermsOfService = "None",
					Contact = new Swashbuckle.AspNetCore.Swagger.Contact { Name = "Fashion", Email = "Fashion@xxx.com", Url = "https://www.jianshu.com/u/94102b59cc2a" }
				});

				try
				{
					//就是这里

					#region 读取xml信息
					var xmlPath = Path.Combine(basePath, "Fashion.Api.xml");//这个就是刚刚配置的xml文件名
					var xmlModelPath = Path.Combine(basePath, "Fashion.Model.xml");//这个就是Model层的xml文件名
					c.IncludeXmlComments(xmlPath, true);//默认的第二个参数是false，这个是controller的注释，记得修改
					c.IncludeXmlComments(xmlModelPath);
					#endregion
				}
				catch (Exception ex)
				{
					log.Error("Blog.Core.xml和Blog.Core.Model.xml 丢失，请检查并拷贝。\n" + ex.Message);
				}

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
		}
	}
}

using Fashion.Api.Seed;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Fashion.Api
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var host = CreateWebHostBuilder(args).Build();

			// 创建可用于解析作用域服务的新 Microsoft.Extensions.DependencyInjection.IServiceScope。
			using (var scope = host.Services.CreateScope())
			{
				var services = scope.ServiceProvider;
				var loggerFactory = services.GetRequiredService<ILoggerFactory>();

				try
				{
					// 从 system.IServicec提供程序获取 T 类型的服务。
					// 为了大家的数据安全，这里先注释掉了，大家自己先测试玩一玩吧。
					// 数据库连接字符串是在 Model 层的 Seed 文件夹下的 MyContext.cs 中
					var configuration = services.GetRequiredService<IConfiguration>();
					if (configuration.GetSection("AppSettings")["SeedDBEnabled"].ObjToBool())
					{
						var myContext = services.GetRequiredService<MyContext>();
						DBSeed.SeedAsync(myContext).Wait();
					}
				}
				catch (Exception e)
				{
					var logger = loggerFactory.CreateLogger<Program>();
					logger.LogError(e, "Error occured seeding the Database.");
					throw;
				}
			}

			host.Run();
		}

		public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
			WebHost.CreateDefaultBuilder(args)
				.UseStartup<Startup>();
	}
}

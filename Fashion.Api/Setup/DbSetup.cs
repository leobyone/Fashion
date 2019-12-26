using Fashion.Api.Seed;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fashion.Api.Setup
{
	/// <summary>
	/// 数据库设置
	/// </summary>
	public static class DbSetup
	{
		public static void AddDbSetup(this IServiceCollection services)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));

			services.AddScoped<DBSeed>();
			services.AddScoped<MyContext>();
		}
	}
}

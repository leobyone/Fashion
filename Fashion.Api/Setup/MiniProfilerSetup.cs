﻿using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fashion.Api.Setup
{
	/// <summary>
	/// MiniProfiler设置
	/// </summary>
	public static class MiniProfilerSetup
	{
		public static void AddMiniProfilerSetup(this IServiceCollection services)
		{
			if (services == null) throw new ArgumentNullException(nameof(services));

			//services.AddMiniProfiler(options =>
			//{
			//	options.RouteBasePath = "/profiler";
			//	//(options.Storage as MemoryCacheStorage).CacheDuration = TimeSpan.FromMinutes(10);
			//	options.PopupRenderPosition = StackExchange.Profiling.RenderPosition.Left;
			//	options.PopupShowTimeWithChildren = true;

			//	// 可以增加权限
			//	//options.ResultsAuthorize = request => request.HttpContext.User.IsInRole("Admin");
			//	//options.UserIdProvider = request => request.HttpContext.User.Identity.Name;
			//}
		 //  );
		}
	}
}

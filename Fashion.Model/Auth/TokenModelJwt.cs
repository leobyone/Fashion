﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fashion.Model.Auth
{
	/// <summary>
	/// 令牌
	/// </summary>
	public class TokenModelJwt
	{
		/// <summary>
		/// Id
		/// </summary>
		public int UserId { get; set; }
		/// <summary>
		/// 角色
		/// </summary>
		public string Role { get; set; }
		/// <summary>
		/// 职能
		/// </summary>
		public string Work { get; set; }

	}
}

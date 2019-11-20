using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Dtos
{
	public class UserDto
	{
		public int Id { get; set; }
		/// <summary>
		/// 登录账号
		/// </summary>
		public string LoginName { get; set; }
		/// <summary>
		/// 手机号码
		/// </summary>
		public string Mobile { get; set; }

		/// <summary>
		/// 真实姓名
		/// </summary>
		public string RealName { get; set; }
		/// <summary>
		/// 状态
		/// </summary>
		public int Status { get; set; }
		/// <summary>
		/// 备注
		/// </summary>
		public string Remark { get; set; }
		/// <summary>
		///错误次数 
		/// </summary>
		public int LoginErrorCount { get; set; }
		// 性别
		public int Sex { get; set; }
		// 年龄
		public int Age { get; set; }
		// 生日
		public DateTime Birthday { get; set; }
		// 地址
		public string Address { get; set; }

		//头像
		public string Avatar { get; set; }

		public string RoleIds { get; set; }
	}
}

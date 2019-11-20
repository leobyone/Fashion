using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Dtos
{
	public class RoleDto
	{
		public int Id { get; set; }
		/// <summary>
		/// 角色名
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		///描述
		/// </summary>
		public string Description { get; set; }
		/// <summary>
		/// 是否激活
		/// </summary>
		public bool Enabled { get; set; }
	}
}

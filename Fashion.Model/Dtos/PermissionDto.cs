using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Dtos
{
	public class PermissionDto
	{
		public int Id { get; set; }

		public string Code { get; set; }

		public string Name { get; set; }

		public string ParentName { get; set; }

		public bool IsButton { get; set; }

		public bool? IsHide { get; set; }

		public int ParentId { get; set; }

		public int ModuleId { get; set; }

		public int OrderSort { get; set; }

		public string Icon { get; set; }

		public string Description { get; set; }

		public bool Enabled { get; set; }

		/// <summary>
		/// 执行方法
		/// </summary>
		public string Action { get; set; }
	}
}

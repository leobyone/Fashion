using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Dtos
{
	public class CategoryDto
	{
		/// <summary>
		/// 分类名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 父id
		/// </summary>
		public int ParentId { get; set; }

		/// <summary>
		/// 层级
		/// </summary>
		public int Layer { get; set; }

		/// <summary>
		/// 分类排序
		/// </summary>
		public int OrderSort { get; set; }

		/// <summary>
		/// 分类路径
		/// </summary>
		public string Path { get; set; }

		public bool IsShow { get; set; }
	}
}

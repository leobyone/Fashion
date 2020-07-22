using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Dtos
{
	public class BrandDto
	{
		/// <summary>
		/// 品牌名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 品牌logo
		/// </summary>
		public string Logo { get; set; }

		/// <summary>
		/// 品牌排序
		/// </summary>
		public int OrderSort { get; set; }

		/// <summary>
		/// 是否显示
		/// </summary>
		public bool IsShow { get; set; }
	}
}

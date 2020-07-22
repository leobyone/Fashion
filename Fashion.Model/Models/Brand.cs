using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Models
{
	/// <summary>
	/// 品牌表
	/// </summary>
	public class Brand : BaseEntity, IAudited, ISoftDelete
	{
		/// <summary>
		/// 品牌名称
		/// </summary>
		[SugarColumn(Length = 50, IsNullable = false)]
		public string Name { get; set; }

		/// <summary>
		/// 品牌logo
		/// </summary>
		[SugarColumn(IsNullable = false)]
		public string Logo { get; set; }

		/// <summary>
		/// 是否显示
		/// </summary>
		public bool IsShow { get; set; }

		/// <summary>
		/// 品牌排序
		/// </summary>
		public int OrderSort { get; set; }

		public int? CreatorUserId { get; set; }

		public DateTime CreationTime { get; set; }

		public int? LastModifierUserId { get; set; }

		public DateTime? LastModificationTime { get; set; }

		public bool IsDeleted { get; set; }
	}
}

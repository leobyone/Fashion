using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Models
{
	/// <summary>
	///商品图片表
	/// </summary>
	public class ProductImage : BaseEntity, IAudited, ISoftDelete
	{
		/// <summary>
		/// 商品id
		/// </summary>
		[SugarColumn(IsNullable = false)]
		public int ProductId { get; set; }

		/// <summary>
		/// 商品图片
		/// </summary>
		public string ShowImg { get; set; }

		/// <summary>
		/// 是否为主图
		/// </summary>
		[SugarColumn(IsNullable = false)]
		public int IsMain { get; set; }

		/// <summary>
		/// 商品图片排序
		/// </summary>
		public int OrderSort { get; set; }
		public int? CreatorUserId { get; set; }
		public DateTime CreationTime { get; set; }
		public int? LastModifierUserId { get; set; }
		public DateTime? LastModificationTime { get; set; }
		public bool IsDeleted { get; set; }
	}
}

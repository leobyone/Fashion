using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Models
{
	/// <summary>
	/// 商品sku表
	/// </summary>
	public class ProductSku : BaseEntity, IAudited, ISoftDelete
	{
		/// <summary>
		/// sku组id
		/// </summary>
		public int SKUGid { get; set; }

		/// <summary>
		/// 商品id
		/// </summary>
		public int ProductId { get; set; }

		/// <summary>
		/// 属性id
		/// </summary>
		public int AttributeId { get; set; }

		/// <summary>
		/// 属性值id
		/// </summary>
		public int AttributeValueId { get; set; }

		public int? CreatorUserId { get; set; }

		public DateTime CreationTime { get; set; }

		public int? LastModifierUserId { get; set; }

		public DateTime? LastModificationTime { get; set; }

		public bool IsDeleted { get; set; }
	}
}

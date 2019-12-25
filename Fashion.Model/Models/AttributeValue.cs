using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Models
{
	/// <summary>
	/// 属性值表
	/// </summary>
	public class AttributeValue : BaseEntity, IAudited, ISoftDelete
	{
		/// <summary>
		/// 属性id
		/// </summary>
		public int AttributeId { get; set; }

		/// <summary>
		/// 属性值
		/// </summary>
		[SugarColumn(IsNullable = false)]
		public string Value { get; set; }

		/// <summary>
		/// 属性值排序
		/// </summary>
		public int OrderSort { get; set; }

		public int? CreatorUserId { get; set; }

		public DateTime CreationTime { get; set; }

		public int? LastModifierUserId { get; set; }

		public DateTime? LastModificationTime { get; set; }

		public bool IsDeleted { get; set; }
	}
}

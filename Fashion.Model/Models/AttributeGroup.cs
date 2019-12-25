using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Models
{
	/// <summary>
	/// 属性分组表
	/// </summary>
	public class AttributeGroup : BaseEntity, IAudited, ISoftDelete
	{
		/// <summary>
		/// 分组名称
		/// </summary>
		[SugarColumn(Length = 50, IsNullable = false)]
		public string Name { get; set; }

		/// <summary>
		/// 分类id
		/// </summary>
		public int CategoryId { get; set; }

		/// <summary>
		/// 分组排序
		/// </summary>
		public int OrderSort { get; set; }

		public int? CreatorUserId { get; set; }

		public DateTime CreationTime { get; set; }

		public int? LastModifierUserId { get; set; }

		public DateTime? LastModificationTime { get; set; }

		public bool IsDeleted { get; set; }
	}
}

using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Models
{
	/// <summary>
	/// 属性表
	/// </summary>
	public class Attribute : BaseEntity, IAudited, ISoftDelete
	{
		/// <summary>
		/// 属性名称
		/// </summary>
		[SugarColumn(Length = 50, IsNullable = false)]
		public string Name { get; set; }

		/// <summary>
		/// 分组id
		/// </summary>
		public int AttributeGroupId { get; set; }

		/// <summary>
		/// 展示类型(0代表文字,1代表图片)
		/// </summary>
		public int ShowType { get; set; }

		/// <summary>
		/// 是否是筛选属性
		/// </summary>
		public int IsFilter { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		public int OrderSort { get; set; }

		public int? CreatorUserId { get; set; }

		public DateTime CreationTime { get; set; }

		public int? LastModifierUserId { get; set; }

		public DateTime? LastModificationTime { get; set; }

		public bool IsDeleted { get; set; }
	}
}

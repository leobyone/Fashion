using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Models
{
	/// <summary>
	/// 分类表
	/// </summary>
	public class Category : BaseEntity, IAudited, ISoftDelete
	{
		/// <summary>
		/// 分类名称
		/// </summary>
		[SugarColumn(Length = 50, IsNullable = false)]
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
		/// 是否有子节点
		/// </summary>
		public int HasChild { get; set; }

		/// <summary>
		/// 分类排序
		/// </summary>
		public int OrderSort { get; set; }

		/// <summary>
		/// 分类路径
		/// </summary>
		public string Path { get; set; }

		public bool IsShow { get; set; }

		public int? CreatorUserId { get; set; }

		public DateTime CreationTime { get; set; }

		public int? LastModifierUserId { get; set; }

		public DateTime? LastModificationTime { get; set; }

		public bool IsDeleted { get; set; }
	}
}

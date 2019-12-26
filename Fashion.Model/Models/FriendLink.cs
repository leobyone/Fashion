using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Models
{
	/// <summary>
	/// 友情链接
	/// </summary>
	public class FriendLink : BaseEntity, IAudited, ISoftDelete
	{
		/// <summary>
		/// 名称
		/// </summary>
		[SugarColumn(Length = 50, IsNullable = false)]
		public string Name { get; set; }

		public string Title { get; set; }

		public string Logo { get; set; }

		public int Layer { get; set; }

		/// <summary>
		/// 链接
		/// </summary>
		[SugarColumn(IsNullable = false)]
		public string Url { get; set; }

		public int Target { get; set; }

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

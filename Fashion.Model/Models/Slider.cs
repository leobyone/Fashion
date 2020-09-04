using SqlSugar;
using System;

namespace Fashion.Model.Models
{
	/// <summary>
	/// ÂÖ²¥Í¼±í
	/// </summary>
	public class Slider : BaseEntity, IAudited, ISoftDelete
	{
		/// <summary>
		/// Ãû³Æ
		/// </summary>
		[SugarColumn(Length = 50, IsNullable = false)]
		public string Title { get; set; }

		public string Image { get; set; }

		/// <summary>
		/// Á´½Ó
		/// </summary>
		[SugarColumn(IsNullable = false)]
		public string Url { get; set; }

		/// <summary>
		/// ÅÅÐò
		/// </summary>
		public int OrderSort { get; set; }

		public string Description { get; set; }

		public int? CreatorUserId { get; set; }

		public DateTime CreationTime { get; set; }

		public int? LastModifierUserId { get; set; }

		public DateTime? LastModificationTime { get; set; }

		public bool IsDeleted { get; set; }
	}
}

	
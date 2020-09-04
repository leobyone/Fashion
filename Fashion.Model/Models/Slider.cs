using SqlSugar;
using System;

namespace Fashion.Model.Models
{
	/// <summary>
	/// �ֲ�ͼ��
	/// </summary>
	public class Slider : BaseEntity, IAudited, ISoftDelete
	{
		/// <summary>
		/// ����
		/// </summary>
		[SugarColumn(Length = 50, IsNullable = false)]
		public string Title { get; set; }

		public string Image { get; set; }

		/// <summary>
		/// ����
		/// </summary>
		[SugarColumn(IsNullable = false)]
		public string Url { get; set; }

		/// <summary>
		/// ����
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

	
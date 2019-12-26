using SqlSugar;
using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Models
{
	/// <summary>
	/// 区域表
	/// </summary>
	public class Region : BaseEntity, IAudited, ISoftDelete
	{
		[SugarColumn(Length = 50, IsNullable = false)]
		public string Name { get; set; }

		public string Spell { get; set; }

		public string ShortSpell { get; set; }

		public string ParentId { get; set; }

		public int Layer { get; set; }

		public int ProvinceId { get; set; }

		public string ProvinceName { get; set; }

		public int CityId { get; set; }

		public string CityName { get; set; }

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

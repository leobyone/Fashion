using SqlSugar;
using System;

namespace Fashion.Model.Models
{
	/// <summary>
	/// 接口API地址信息表
	/// </summary>
	public class Module : BaseEntity, IAudited, ISoftDelete
	{
		public Module()
		{
			this.CreationTime = DateTime.Now;
			this.LastModificationTime = DateTime.Now;
		}

		/// <summary>
		/// 父ID
		/// </summary>
		[SugarColumn(IsNullable = true)]
		public int? ParentId { get; set; }
		/// <summary>
		/// 名称
		/// </summary>
		[SugarColumn(Length = 50, IsNullable = true)]
		public string Name { get; set; }
		/// <summary>
		/// 菜单链接地址
		/// </summary>
		[SugarColumn(Length = 100, IsNullable = true)]
		public string LinkUrl { get; set; }
		/// <summary>
		/// 区域名称
		/// </summary>
		[SugarColumn(Length = int.MaxValue, IsNullable = true)]
		public string Area { get; set; }
		/// <summary>
		/// 控制器名称
		/// </summary>
		[SugarColumn(Length = int.MaxValue, IsNullable = true)]
		public string Controller { get; set; }
		/// <summary>
		/// Action名称
		/// </summary>
		[SugarColumn(Length = int.MaxValue, IsNullable = true)]
		public string Action { get; set; }
		/// <summary>
		/// 图标
		/// </summary>
		[SugarColumn(Length = 100, IsNullable = true)]
		public string Icon { get; set; }
		/// <summary>
		/// 菜单编号
		/// </summary>
		[SugarColumn(Length = 10, IsNullable = true)]
		public string Code { get; set; }
		/// <summary>
		/// 排序
		/// </summary>
		public int OrderSort { get; set; }
		/// <summary>
		/// /描述
		/// </summary>
		[SugarColumn(Length = 100, IsNullable = true)]
		public string Description { get; set; }
		/// <summary>
		/// 是否是右侧菜单
		/// </summary>
		public bool IsMenu { get; set; }
		/// <summary>
		/// 是否激活
		/// </summary>
		public bool Enabled { get; set; }

		public DateTime CreationTime { get; set; }
		[SugarColumn(IsNullable = true)]
		public int? CreatorUserId { get; set; }
		[SugarColumn(IsNullable = true)]
		public int? LastModifierUserId { get; set; }
		[SugarColumn(IsNullable = true)]
		public DateTime? LastModificationTime { get; set; }
		[SugarColumn(IsNullable = true)]
		public bool IsDeleted { get; set; }
	}
}

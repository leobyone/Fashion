using SqlSugar;
using System;
using System.Collections.Generic;

namespace Fashion.Model.Models
{
	/// <summary>
	/// 路由菜单表
	/// </summary>
	public class Permission : BaseEntity, IAudited, ISoftDelete
    {
        public Permission()
        {
			this.CreationTime = DateTime.Now;
			this.LastModificationTime = DateTime.Now;
		}

        /// <summary>
        /// 菜单执行Action名
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string Code { get; set; }

		public string Path { get; set; }

        /// <summary>
        /// 菜单显示名（如用户页、编辑(按钮)、删除(按钮)）
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string Name { get; set; }
        /// <summary>
        /// 是否是按钮
        /// </summary>
        public bool IsButton { get; set; } = false;
        /// <summary>
        /// 是否是隐藏菜单
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool? IsHide { get; set; } = false;

        /// <summary>
        /// 上一级菜单（0表示上一级无菜单）
        /// </summary>
        public int ParentId { get; set; }

        /// <summary>
        /// 接口api
        /// </summary>
        public int ModuleId { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        public int OrderSort { get; set; }
        /// <summary>
        /// 菜单图标
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string Icon { get; set; }
        /// <summary>
        /// 菜单描述    
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string Description { get; set; }
        /// <summary>
        /// 激活状态
        /// </summary>
        public bool Enabled { get; set; }

		/// <summary>
		/// 执行方法
		/// </summary>
		public string Action { get; set; }

		public DateTime CreationTime { get; set; }
		[SugarColumn(IsNullable = true)]
		public int? CreatorUserId { get; set; }
		[SugarColumn(IsNullable = true)]
		public int? LastModifierUserId { get; set; }
		[SugarColumn(IsNullable = true)]
		public DateTime? LastModificationTime { get; set; }

		/// <summary>
		///获取或设置是否禁用，逻辑上的删除，非物理删除
		/// </summary>
		[SugarColumn(IsNullable = true)]
        public bool IsDeleted { get; set; }
    }
}

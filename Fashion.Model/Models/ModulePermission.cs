using SqlSugar;
using System;

namespace Fashion.Model.Models
{
	/// <summary>
	/// 菜单与按钮关系表
	/// </summary>
	public class ModulePermission : BaseEntity, IAudited, ISoftDelete
    {
		public ModulePermission()
		{
			this.CreationTime = DateTime.Now;
			this.LastModificationTime = DateTime.Now;
		}

        /// <summary>
        ///获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public int ModuleId { get; set; }
        /// <summary>
        /// 按钮ID
        /// </summary>
        public int PermissionId { get; set; }

		public DateTime CreationTime { get; set; }
		[SugarColumn(IsNullable = true)]
		public int? CreatorUserId { get; set; }
		[SugarColumn(IsNullable = true)]
		public int? LastModifierUserId { get; set; }
		[SugarColumn(IsNullable = true)]
		public DateTime? LastModificationTime { get; set; }
	}
}

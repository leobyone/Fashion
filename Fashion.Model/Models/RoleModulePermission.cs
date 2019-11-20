using SqlSugar;
using System;

namespace Fashion.Model.Models
{
    /// <summary>
    /// 按钮跟权限关联表
    /// </summary>
    public class RoleModulePermission : BaseEntity, IAudited, ISoftDelete
    {
        public RoleModulePermission()
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
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }
        /// <summary>
        /// 菜单ID
        /// </summary>
        public int ModuleId { get; set; }
        /// <summary>
        /// 按钮ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public int? PermissionId { get; set; }
		public DateTime CreationTime { get; set; }
		[SugarColumn(IsNullable = true)]
		public int? CreatorUserId { get; set; }
		[SugarColumn(IsNullable = true)]
		public int? LastModifierUserId { get; set; }
		[SugarColumn(IsNullable = true)]
		public DateTime? LastModificationTime { get; set; }

		// 下边三个实体参数，只是做传参作用，所以忽略下
		[SugarColumn(IsIgnore = true)]
        public Role Role { get; set; }
        [SugarColumn(IsIgnore = true)]
        public Module Module { get; set; }
        [SugarColumn(IsIgnore = true)]
        public Permission Permission { get; set; }
    }
}

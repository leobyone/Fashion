using SqlSugar;
using System;

namespace Fashion.Model.Models
{
	/// <summary>
	/// 用户跟角色关联表
	/// </summary>
	public class UserRole : BaseEntity, IAudited, ISoftDelete
    {
        public UserRole()
		{
			this.CreationTime = DateTime.Now;
			this.LastModificationTime = DateTime.Now;
		}

        public UserRole(int uid, int rid)
        {
            UserId = uid;
            RoleId = rid;
            IsDeleted = false;
			CreatorUserId = uid;
			CreationTime = DateTime.Now;
        }

        /// <summary>
        ///获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 角色ID
        /// </summary>
        public int RoleId { get; set; }
		public DateTime CreationTime { get; set; }
		[SugarColumn(IsNullable = true)]
		public int? CreatorUserId { get; set; }
		[SugarColumn(IsNullable = true)]
		public int? LastModifierUserId { get; set; }
		[SugarColumn(IsNullable = true)]
		public DateTime? LastModificationTime { get; set; }

	}
}

using SqlSugar;
using System;

namespace Fashion.Model.Models
{
	/// <summary>
	/// 角色表
	/// </summary>
	public class Role : BaseEntity, IAudited, ISoftDelete
    {
        public Role()
        {
            OrderSort = 1;
			CreationTime = DateTime.Now;
			LastModificationTime = DateTime.Now;
            IsDeleted = false;
        }
        public Role(string name)
        {
            Name = name;
            Description = "";
            OrderSort = 1;
            Enabled = false;
			CreationTime = DateTime.Now;
			LastModificationTime = DateTime.Now;
        }

        /// <summary>
        ///获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool IsDeleted { get; set; }
        /// <summary>
        /// 角色名
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string Name { get; set; }
        /// <summary>
        ///描述
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string Description { get; set; }
        /// <summary>
        ///排序
        /// </summary>
        public int OrderSort { get; set; }
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
	}
}

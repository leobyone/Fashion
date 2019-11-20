using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Model.Models
{
    /// <summary>
    /// 用户信息表
    /// </summary>
    public class User: BaseEntity, IHasCreationTime, IHasModificationTime, ISoftDelete
    {
        public User()
		{
			this.CreationTime = DateTime.Now;
			this.LastModificationTime = DateTime.Now;
		}

        /// <summary>
        /// 登录账号
        /// </summary>
        [SugarColumn(Length = 60, IsNullable = true)]
        public string LoginName { get; set; }
        /// <summary>
        /// 登录密码
        /// </summary>
        [SugarColumn(Length = 30, IsNullable = true)]
        public string Password { get; set; }
		/// <summary>
		/// 手机号码
		/// </summary>
		[SugarColumn(Length = 30, IsNullable = true)]
		public string Mobile { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        [SugarColumn(Length = 60, IsNullable = true)]
        public string RealName { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        public int Status { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        [SugarColumn(Length = int.MaxValue, IsNullable = true)]
        public string Remark { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreationTime { get; set; }
		/// <summary>
		/// 最后修改时间
		/// </summary>
		public DateTime? LastModificationTime { get; set; }
		/// <summary>
		///最后登录时间 
		/// </summary>
		public DateTime LastLoginTime { get; set; }
        /// <summary>
        ///错误次数 
        /// </summary>
        public int LoginErrorCount { get; set; }
        // 性别
        [SugarColumn(IsNullable = true)]
        public int Sex { get; set; }
        // 年龄
        [SugarColumn(IsNullable = true)]
        public int Age { get; set; }
        // 生日
        [SugarColumn(IsNullable = true)]
        public DateTime Birthday { get; set; }
        // 地址
        [SugarColumn(Length = 200, IsNullable = true)]
        public string Address { get; set; }

        [SugarColumn(IsNullable = true)]
        public bool IsDeleted { get; set; }

		//头像
		[SugarColumn(IsNullable = true)]
		public string Avatar { get; set; }

		[SugarColumn(IsIgnore = true)]
        public string RoleIds { get; set; }
		
	}
}

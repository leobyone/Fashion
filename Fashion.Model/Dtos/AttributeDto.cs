using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Dtos
{
	public class AttributeDto
	{
		public int Id { get; set; }

		/// <summary>
		/// 属性名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 分组id
		/// </summary>
		public int AttributeGroupId { get; set; }

		/// <summary>
		/// 分组名
		/// </summary>
		public string AttributeGroupName { get; set; }

		/// <summary>
		/// 展示类型(0代表属性,1代表参数)
		/// </summary>
		public int ShowType { get; set; }

		/// <summary>
		/// 是否是筛选属性
		/// </summary>
		public int IsFilter { get; set; }

		/// <summary>
		/// 属性是否可选（0代表唯一，1代表单选，2代表多选）
		/// </summary>
		public int SelectType { get; set; }

		/// <summary>
		/// 属性值
		/// </summary>
		public string Values { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		public int OrderSort { get; set; }
	}
}

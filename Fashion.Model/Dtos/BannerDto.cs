using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Dtos
{
	public class BannerDto
	{
		public int Id { get; set; }

		public string Title { get; set; }

		public string Image { get; set; }

		public string Url { get; set; }

		public int Target { get; set; }

		/// <summary>
		/// 排序
		/// </summary>
		public int OrderSort { get; set; }

		public bool IsDeleted { get; set; }
	}
}

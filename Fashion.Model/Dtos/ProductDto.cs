using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Dtos
{
	public class ProductDto
	{
		/// <summary>
		/// 商品货号
		/// </summary>
		public string PSN { get; set; }

		/// <summary>
		/// 商品分类id
		/// </summary>
		public int CategoryId { get; set; }

		/// <summary>
		/// 商品品牌id
		/// </summary>
		public int BrandId { get; set; }

		/// <summary>
		/// 商品品牌名称
		/// </summary>
		public int BrandName { get; set; }

		/// <summary>
		/// 商品sku组id
		/// </summary>
		public int SKUGid { get; set; }

		/// <summary>
		/// 商品名称
		/// </summary>
		public string Name { get; set; }

		/// <summary>
		/// 商品商城价
		/// </summary>
		public decimal ShopPrice { get; set; }

		/// <summary>
		/// 商品市场价
		/// </summary>
		public decimal MarketPrice { get; set; }

		/// <summary>
		/// 商品成本价
		/// </summary>
		public decimal CostPrice { get; set; }

		/// <summary>
		/// 0代表草稿，1代表上架，2代表下架，3代表回收站
		/// </summary>
		public int Status { get; set; }

		/// <summary>
		/// 商品是否精品
		/// </summary>
		public int IsBest { get; set; }

		/// <summary>
		/// 商品是否热销
		/// </summary>
		public int IsHot { get; set; }

		/// <summary>
		/// 商品是否新品
		/// </summary>
		public int IsNew { get; set; }

		/// <summary>
		/// 商品排序
		/// </summary>
		public int OrderSort { get; set; }

		/// <summary>
		/// 商品重量
		/// </summary>
		public int Weight { get; set; }

		/// <summary>
		/// 商品展示图片
		/// </summary>
		public string ShowImg { get; set; }

		/// <summary>
		/// 销售数
		/// </summary>
		public int SaleCount { get; set; }

		/// <summary>
		/// 访问数
		/// </summary>
		public int VisitCount { get; set; }

		/// <summary>
		/// 评价数
		/// </summary>
		public int ReviewCount { get; set; }

		/// <summary>
		/// 评价星星1
		/// </summary>
		public int Star1 { get; set; }

		/// <summary>
		/// 评价星星2
		/// </summary>
		public int Star2 { get; set; }

		/// <summary>
		/// 评价星星3
		/// </summary>
		public int Star3 { get; set; }

		/// <summary>
		/// 评价星星4
		/// </summary>
		public int Star4 { get; set; }

		/// <summary>
		/// 评价星星5
		/// </summary>
		public int Star5 { get; set; }

		/// <summary>
		/// 商品描述
		/// </summary>
		public string Description { get; set; }
	}
}

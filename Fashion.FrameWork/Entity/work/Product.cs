
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// Product
	/// </summary>	
	public class Product
	{

	  public int  Id { get; set; }

	  public string  PSN { get; set; }

	  public int  CategoryId { get; set; }

	  public int  BrandId { get; set; }

	  public int  SKUGid { get; set; }

	  public string  Name { get; set; }

	  public decimal  ShopPrice { get; set; }

	  public decimal  MarketPrice { get; set; }

	  public decimal  CostPrice { get; set; }

	  public int  Status { get; set; }

	  public int  IsBest { get; set; }

	  public int  IsHot { get; set; }

	  public int  IsNew { get; set; }

	  public int  OrderSort { get; set; }

	  public int  Weight { get; set; }

	  public string  ShowImg { get; set; }

	  public int  SaleCount { get; set; }

	  public int  VisitCount { get; set; }

	  public int  ReviewCount { get; set; }

	  public int  Star1 { get; set; }

	  public int  Star2 { get; set; }

	  public int  Star3 { get; set; }

	  public int  Star4 { get; set; }

	  public int  Star5 { get; set; }

	  public string  Description { get; set; }

	  public int  CreatorUserId { get; set; }

	  public DateTime  CreationTime { get; set; }

	  public int  LastModifierUserId { get; set; }

	  public DateTime  LastModificationTime { get; set; }

	  public bool  IsDeleted { get; set; }

	  public string  Unit { get; set; }

	  public string  Detail { get; set; }

	  public string  BrandName { get; set; }

	  public string  CategoryName { get; set; }
 
    }
}

	
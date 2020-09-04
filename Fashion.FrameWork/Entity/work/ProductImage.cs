
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// ProductImage
	/// </summary>	
	public class ProductImage
	{

	  public int  Id { get; set; }

	  public int  ProductId { get; set; }

	  public string  ShowImg { get; set; }

	  public int  IsMain { get; set; }

	  public int  OrderSort { get; set; }

	  public int  CreatorUserId { get; set; }

	  public DateTime  CreationTime { get; set; }

	  public int  LastModifierUserId { get; set; }

	  public DateTime  LastModificationTime { get; set; }

	  public bool  IsDeleted { get; set; }
 
    }
}

	
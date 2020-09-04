
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// ProductSku
	/// </summary>	
	public class ProductSku
	{

	  public int  Id { get; set; }

	  public int  SKUGid { get; set; }

	  public int  ProductId { get; set; }

	  public int  AttributeId { get; set; }

	  public int  AttributeValueId { get; set; }

	  public int  CreatorUserId { get; set; }

	  public DateTime  CreationTime { get; set; }

	  public int  LastModifierUserId { get; set; }

	  public DateTime  LastModificationTime { get; set; }

	  public bool  IsDeleted { get; set; }
 
    }
}

	
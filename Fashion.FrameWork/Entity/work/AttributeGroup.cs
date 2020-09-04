
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// AttributeGroup
	/// </summary>	
	public class AttributeGroup
	{

	  public int  Id { get; set; }

	  public string  Name { get; set; }

	  public int  CategoryId { get; set; }

	  public int  OrderSort { get; set; }

	  public int  CreatorUserId { get; set; }

	  public DateTime  CreationTime { get; set; }

	  public int  LastModifierUserId { get; set; }

	  public DateTime  LastModificationTime { get; set; }

	  public bool  IsDeleted { get; set; }
 
    }
}

	
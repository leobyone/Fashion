
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// AttributeValue
	/// </summary>	
	public class AttributeValue
	{

	  public int  Id { get; set; }

	  public int  AttributeId { get; set; }

	  public string  Value { get; set; }

	  public int  OrderSort { get; set; }

	  public int  CreatorUserId { get; set; }

	  public DateTime  CreationTime { get; set; }

	  public int  LastModifierUserId { get; set; }

	  public DateTime  LastModificationTime { get; set; }

	  public bool  IsDeleted { get; set; }
 
    }
}

	
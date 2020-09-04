
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// Attribute
	/// </summary>	
	public class Attribute
	{

	  public int  Id { get; set; }

	  public string  Name { get; set; }

	  public int  AttributeGroupId { get; set; }

	  public int  ShowType { get; set; }

	  public int  IsFilter { get; set; }

	  public int  OrderSort { get; set; }

	  public int  CreatorUserId { get; set; }

	  public DateTime  CreationTime { get; set; }

	  public int  LastModifierUserId { get; set; }

	  public DateTime  LastModificationTime { get; set; }

	  public bool  IsDeleted { get; set; }

	  public bool  SelectType { get; set; }

	  public string  Values { get; set; }

	  public bool  canManuallyAdd { get; set; }
 
    }
}

	
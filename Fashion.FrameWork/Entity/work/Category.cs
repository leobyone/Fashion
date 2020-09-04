
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// Category
	/// </summary>	
	public class Category
	{

	  public int  Id { get; set; }

	  public string  Name { get; set; }

	  public int  ParentId { get; set; }

	  public int  Layer { get; set; }

	  public int  HasChild { get; set; }

	  public int  OrderSort { get; set; }

	  public string  Path { get; set; }

	  public int  CreatorUserId { get; set; }

	  public DateTime  CreationTime { get; set; }

	  public int  LastModifierUserId { get; set; }

	  public DateTime  LastModificationTime { get; set; }

	  public bool  IsDeleted { get; set; }

	  public bool  IsShow { get; set; }
 
    }
}

	
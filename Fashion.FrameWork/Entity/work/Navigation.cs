
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// Navigation
	/// </summary>	
	public class Navigation
	{

	  public int  Id { get; set; }

	  public string  Name { get; set; }

	  public string  Title { get; set; }

	  public int  ParentId { get; set; }

	  public int  Layer { get; set; }

	  public string  Url { get; set; }

	  public int  Target { get; set; }

	  public int  OrderSort { get; set; }

	  public int  CreatorUserId { get; set; }

	  public DateTime  CreationTime { get; set; }

	  public int  LastModifierUserId { get; set; }

	  public DateTime  LastModificationTime { get; set; }

	  public bool  IsDeleted { get; set; }
 
    }
}

	
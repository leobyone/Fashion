
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// Role
	/// </summary>	
	public class Role
	{

	  public int  Id { get; set; }

	  public bool  ? IsDeleted { get; set; }

	  public string  Name { get; set; }

	  public string  Description { get; set; }

	  public int  OrderSort { get; set; }

	  public bool  Enabled { get; set; }

	  public DateTime  CreationTime { get; set; }

	  public int  ? CreatorUserId { get; set; }

	  public int  ? LastModifierUserId { get; set; }

	  public DateTime  ? LastModificationTime { get; set; }
 
    }
}

	
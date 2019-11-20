
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// Module
	/// </summary>	
	public class Module
	{

	  public int  Id { get; set; }

	  public int  ? ParentId { get; set; }

	  public string  Name { get; set; }

	  public string  LinkUrl { get; set; }

	  public string  Area { get; set; }

	  public string  Controller { get; set; }

	  public string  Action { get; set; }

	  public string  Icon { get; set; }

	  public string  Code { get; set; }

	  public int  OrderSort { get; set; }

	  public string  Description { get; set; }

	  public bool  IsMenu { get; set; }

	  public bool  Enabled { get; set; }

	  public DateTime  CreationTime { get; set; }

	  public int  ? CreatorUserId { get; set; }

	  public int  ? LastModifierUserId { get; set; }

	  public DateTime  ? LastModificationTime { get; set; }

	  public bool  ? IsDeleted { get; set; }
 
    }
}

	
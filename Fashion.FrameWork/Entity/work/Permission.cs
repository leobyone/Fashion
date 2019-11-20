
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// Permission
	/// </summary>	
	public class Permission
	{

	  public int  Id { get; set; }

	  public string  Code { get; set; }

	  public string  Name { get; set; }

	  public bool  IsButton { get; set; }

	  public bool  ? IsHide { get; set; }

	  public int  Pid { get; set; }

	  public int  Mid { get; set; }

	  public int  OrderSort { get; set; }

	  public string  Icon { get; set; }

	  public string  Description { get; set; }

	  public bool  Enabled { get; set; }

	  public DateTime  CreationTime { get; set; }

	  public int  ? CreatorUserId { get; set; }

	  public int  ? LastModifierUserId { get; set; }

	  public DateTime  ? LastModificationTime { get; set; }

	  public bool  ? IsDeleted { get; set; }
 
    }
}

	
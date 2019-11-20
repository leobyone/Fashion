
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// UserRole
	/// </summary>	
	public class UserRole
	{

	  public int  Id { get; set; }

	  public bool  ? IsDeleted { get; set; }

	  public int  UserId { get; set; }

	  public int  RoleId { get; set; }

	  public DateTime  CreationTime { get; set; }

	  public int  ? CreatorUserId { get; set; }

	  public int  ? LastModifierUserId { get; set; }

	  public DateTime  ? LastModificationTime { get; set; }
 
    }
}

	
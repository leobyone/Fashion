
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// ModulePermission
	/// </summary>	
	public class ModulePermission
	{

	  public int  Id { get; set; }

	  public bool  ? IsDeleted { get; set; }

	  public int  ModuleId { get; set; }

	  public int  PermissionId { get; set; }

	  public DateTime  CreationTime { get; set; }

	  public int  ? CreatorUserId { get; set; }

	  public int  ? LastModifierUserId { get; set; }

	  public DateTime  ? LastModificationTime { get; set; }
 
    }
}

	
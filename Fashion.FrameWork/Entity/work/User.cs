
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// User
	/// </summary>	
	public class User
	{

	  public int  Id { get; set; }

	  public string  LoginName { get; set; }

	  public string  Password { get; set; }

	  public string  Mobile { get; set; }

	  public string  RealName { get; set; }

	  public int  Status { get; set; }

	  public string  Remark { get; set; }

	  public DateTime  CreationTime { get; set; }

	  public DateTime  LastModificationTime { get; set; }

	  public DateTime  LastLoginTime { get; set; }

	  public int  LoginErrorCount { get; set; }

	  public int  ? Sex { get; set; }

	  public int  ? Age { get; set; }

	  public DateTime  ? Birthday { get; set; }

	  public string  Address { get; set; }

	  public bool  ? IsDeleted { get; set; }

	  public string  Avatar { get; set; }
 
    }
}

	
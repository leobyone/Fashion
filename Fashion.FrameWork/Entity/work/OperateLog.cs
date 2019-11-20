
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// OperateLog
	/// </summary>	
	public class OperateLog
	{

	  public int  Id { get; set; }

	  public bool  ? IsDeleted { get; set; }

	  public string  Area { get; set; }

	  public string  Controller { get; set; }

	  public string  Action { get; set; }

	  public string  IPAddress { get; set; }

	  public string  Description { get; set; }

	  public DateTime  ? LogTime { get; set; }

	  public string  LoginName { get; set; }

	  public int  UserId { get; set; }
 
    }
}

	
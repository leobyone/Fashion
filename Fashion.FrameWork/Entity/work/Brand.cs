
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// Brand
	/// </summary>	
	public class Brand
	{

	  public int  Id { get; set; }

	  public string  Name { get; set; }

	  public string  Logo { get; set; }

	  public int  OrderSort { get; set; }

	  public int  CreatorUserId { get; set; }

	  public DateTime  CreationTime { get; set; }

	  public int  LastModifierUserId { get; set; }

	  public DateTime  LastModificationTime { get; set; }

	  public bool  IsDeleted { get; set; }

	  public bool  IsShow { get; set; }

	  public string  BrandStory { get; set; }
 
    }
}

	
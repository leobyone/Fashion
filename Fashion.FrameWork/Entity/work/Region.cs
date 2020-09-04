
    
using System;
namespace Fashion.Model.Models
{	
	/// <summary>
	/// Region
	/// </summary>	
	public class Region
	{

	  public int  Id { get; set; }

	  public string  Name { get; set; }

	  public string  Spell { get; set; }

	  public string  ShortSpell { get; set; }

	  public string  ParentId { get; set; }

	  public int  Layer { get; set; }

	  public int  ProvinceId { get; set; }

	  public string  ProvinceName { get; set; }

	  public int  CityId { get; set; }

	  public string  CityName { get; set; }

	  public int  OrderSort { get; set; }

	  public int  CreatorUserId { get; set; }

	  public DateTime  CreationTime { get; set; }

	  public int  LastModifierUserId { get; set; }

	  public DateTime  LastModificationTime { get; set; }

	  public bool  IsDeleted { get; set; }
 
    }
}

	
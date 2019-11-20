using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Models
{
	public interface ICreationAudited : IHasCreationTime
	{
		int? CreatorUserId { get; set; }
	}
}

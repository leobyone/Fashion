using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Models
{
	public interface ISoftDelete
	{
		bool IsDeleted { get; set; }
	}
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Models
{
	public interface IHasModificationTime
	{
		DateTime? LastModificationTime { get; set; }
	}
}

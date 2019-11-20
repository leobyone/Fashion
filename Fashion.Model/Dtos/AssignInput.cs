using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Dtos
{
	public class AssignInput
	{
		public int roleId { get; set; }
		public List<int> permissionIds { get; set; }
	}
}

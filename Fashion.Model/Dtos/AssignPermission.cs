using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Dtos
{
	public class AssignPermission
	{
		public AssignPermission()
		{
			this.PermissionIds = new List<int>();
			this.AssignBtns = new List<Button>();
		}

		public List<int> PermissionIds { get; set; }
		public List<Button> AssignBtns { get; set; }
	}

	public class Button
	{
		public int Id { get; set; }
		public string Name { get; set; }
	}
}

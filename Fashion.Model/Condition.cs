using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model
{
	public class Condition
	{
		public Condition() { }

		public string Field { get; set; }
		public int? DataType { get; set; }
		public int Option { get; set; }
		public string Value { get; set; }
	}
}

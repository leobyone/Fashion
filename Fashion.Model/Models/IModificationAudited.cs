﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Fashion.Model.Models
{
	public interface IModificationAudited : IHasModificationTime
	{
		int? LastModifierUserId { get; set; }
	}
}

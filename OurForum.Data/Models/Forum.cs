﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OurForum.Data.Models
{
	public class Forum
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Created { get; set; }
		public string ImageUrl { get; set; }
		public virtual IEnumerable<post> Posts { get; set; }
	}
}

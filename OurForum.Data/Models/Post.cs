﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OurForum.Data.Models
{
	public class post
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
		public DateTime Created { get; set; }

		public virtual ApplicationUser User { get; set; }
		public virtual Forum Forum { get; set; }

		public virtual IEnumerable<PostReply> Reply { get; set; }
	}
}

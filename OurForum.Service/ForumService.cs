using OurForum.Data.Interface;
using OurForum.Data.Models;
using OurForum.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace OurForum.Service
{
	public class ForumService : IForum
	{
		private readonly ApplicationDbContext _context;
		public ForumService(ApplicationDbContext context)
		{
			_context = context;
		}
		public Task Create(Data.Models.Forum forum)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int forumId)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<Data.Models.Forum> GetAll()
		{
			return _context.Forums
				.Include(forum=>forum.Posts);
		}

		public IEnumerable<ApplicationUser> GetAllActiveUsers()
		{
			throw new NotImplementedException();
		}

		public Forum GetById(int id)
		{
			var forum = _context.Forums.Where(f => f.Id == id)
				.Include(f => f.Posts)
				.ThenInclude(p => p.User)
				.Include(f => f.Posts)
				.ThenInclude(p => p.Reply)
				.ThenInclude(r=>r.User)
				.FirstOrDefault();
			return forum;
		}

		public Task UpdateForumDescription(int forumId, string newDescription)
		{
			throw new NotImplementedException();
		}

		public Task UpdateForumTitle(int forumId, string newTitle)
		{
			throw new NotImplementedException();
		}

		Data.Models.Forum IForum.GetById(int id)
		{
			throw new NotImplementedException();
		}
	}
}

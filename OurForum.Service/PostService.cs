using Microsoft.EntityFrameworkCore;
using OurForum.Data;
using OurForum.Data.Interface;
using OurForum.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OurForum.Service
{
	public class PostService : IPost
	{
		private readonly ApplicationDbContext _context;
		public PostService(ApplicationDbContext context)
		{
			_context = context; 
		}
		public Task Add(post post)
		{
			throw new NotImplementedException();
		}

		public Task Delete(int id)
		{
			throw new NotImplementedException();
		}

		public Task EditPostContent(int id, string newContent)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<post> GetAll()
		{
			throw new NotImplementedException();
		}

		public post GetById(int id)
		{
			return _context.Posts.Where(post => post.Id == id)
				.Include(post => post.User)
				.Include(post => post.Reply)
				.ThenInclude(reply=>reply.User)
				.Include(post => post.Forum)
				.First();

		}

		public IEnumerable<post> GetFilteredPosts(string searchQuery)
		{
			throw new NotImplementedException();
		}

		public IEnumerable<post> GetPostsByForum(int id)
		{
			return  _context.Forums
				.Where(Forum => Forum.Id == id)
				.First().Posts;
		}
	}
}

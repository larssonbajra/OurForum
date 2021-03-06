﻿using Microsoft.EntityFrameworkCore;
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
		public async Task Add(post post)
		{
			_context.Add(post);
			await _context.SaveChangesAsync();
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
			return _context.Posts
				.Include(post => post.User)
				.Include(post => post.Reply)
				.ThenInclude(reply => reply.User)
				.Include(post => post.Forum);
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

		public IEnumerable<post> GetLatestPosts(int n)
		{
			return GetAll().OrderByDescending(post => post.Created).Take(n);
		}

		public IEnumerable<post> GetPostsByForum(int id)
		{
			return  _context.Forums
				.Where(Forum => Forum.Id == id)
				.First().Posts;
		}
	}
}

using OurForum.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OurForum.Data.Interface
{
	public interface IPost
	{
		post GetById(int id);
		IEnumerable<post> GetAll();
		IEnumerable<post> GetFilteredPosts(string searchQuery);
		IEnumerable<post> GetPostsByForum(int id);
		IEnumerable<post> GetLatestPosts(int n);
		Task Add(post post);
		Task Delete(int id);
		Task EditPostContent(int id, string newContent);
		

		//Task AddReply(PostReply reply);
	}
}

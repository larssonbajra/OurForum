using OurForum.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OurForum.Data.Interface
{
	public interface IPost
	{
		Post GetById(int id);
		IEnumerable<Post> GetAll();
		IEnumerable<Post> GetFilteredPosts(string searchQuery);
		IEnumerable<Post> GetPostsByForum(int id);

		Task Add(Post post);
		Task Delete(int id);
		Task EditPostContent(int id, string newContent);
	
		//Task AddReply(PostReply reply);
	}
}

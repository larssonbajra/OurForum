using OurForum.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OurForum.Data.Interface
{
	public interface IForum
	{
		Forum GetById(int id);
		IEnumerable<Forum> GetAll();
		IEnumerable<ApplicationUser> GetAllActiveUsers();

		Task Create(Forum forum); // task similar to void, but represents async event
		Task Delete(int forumId);
		Task UpdateForumTitle(int forumId, string newTitle);
		Task UpdateForumDescription(int forumId, string newDescription);
	}
}

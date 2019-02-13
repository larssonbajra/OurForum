using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OurForum.Data.Interface;
using OurForum.Data.Models;
using OurForum.Models.Post;
using OurForum.Models.Reply;

namespace OurForum.Controllers
{
    public class PostController : Controller
    {
		private readonly IPost _postService;
		public PostController(IPost postService)
		{
			_postService = postService;
		}
        public IActionResult Index(int id)
        {
			var post = _postService.GetById(id);
			var replies = BuildPostReplies(post.Reply);
			var model = new PostIndexModel
			{
				Id=post.Id,
				Title=post.Title,
				AuthorId=post.User.Id,
				AuthorName=post.User.UserName,
				AuthorImageUrl=post.User.ProfileImageUrl,
				AuthorRating=post.User.Rating,
				Created=post.Created,
				PostContent=post.Content,
				Replies=replies
			};
            return View(model);
        }

		private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> reply)
		{
			return reply.Select(replies => new PostReplyModel
			{
				Id = replies.Id,
				AuthorName = replies.User.UserName,
				AuthorId = replies.User.Id,
				AuthorImageUrl = replies.User.ProfileImageUrl,
				AuthorRating = replies.User.Rating,
				Created = replies.Created,
				ReplyContent = replies.Content


			});
		}
	}
}
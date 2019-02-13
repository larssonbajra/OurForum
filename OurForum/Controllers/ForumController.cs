using Microsoft.AspNetCore.Mvc;
using OurForum.Data.Interface;
using OurForum.Data.Models;
using OurForum.Models.Forum;
using OurForum.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OurForum.Controllers
{
	public class ForumController : Controller
    {
		private readonly IForum _forumService;
		private readonly IPost _postService;
		public ForumController(IForum forumService, IPost postService)
		{
			_postService = postService;
			_forumService = forumService;
		}
        public IActionResult Index()
        {
			var forums = _forumService.GetAll()
				.Select(forum=>new ForumListingModel {
					Id=forum.Id,
					Name=forum.Title,
					Description=forum.Description
				});
			var model = new ForumIndexModel
			{
				ForumList=forums
			};
            return View(model);
        }
		public IActionResult Topic(int id)
		{
			var forum = _forumService.GetById(id);
			var posts = forum.Posts;

			var postListings = posts.Select(post => new PostListingModel
			{
				Id=post.Id,
				AuthorId=post.User.Id,
				AuthorRating=post.User.Rating,
				Title=post.Title,
				DatePosted=post.Created.ToString(),
				RepliesCount=post.Reply.Count(),
				Forum = BuildForumListing(post)
			});
			var model = new ForumTopicModel
			{
				Posts=postListings,
				Forum=BuildForumListing(forum)
			};
			return View(model);
		}

		private ForumListingModel BuildForumListing(Post post)
		{
			var forum = post.Forum;
			return BuildForumListing(forum);
		}
		private ForumListingModel BuildForumListing(Forum forum)
		{
			
			return new ForumListingModel
			{
				Id = forum.Id,
				Name = forum.Title,
				Description = forum.Description,
				ImageUrl = forum.ImageUrl
			};
		}
	}
}
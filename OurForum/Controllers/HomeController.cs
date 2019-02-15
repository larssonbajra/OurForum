using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OurForum.Data.Interface;
using OurForum.Data.Models;
using OurForum.Models;
using OurForum.Models.Forum;
using OurForum.Models.Home;
using OurForum.Models.Post;

namespace OurForum.Controllers
{
	public class HomeController : Controller
	{
		private readonly IPost _postService;
		public HomeController(IPost postService)
		{
			_postService = postService;

		}
		public IActionResult Index()
		{
			var model = BuildHomeIndexModel();
			return View(model);
		}

		private HomeIndexModel BuildHomeIndexModel()
		{
			var latestPosts = _postService.GetLatestPosts(10);
			var posts = latestPosts.Select(post => new PostListingModel
			{
				Id = post.Id,
				Title = post.Title,
				Author = post.User.UserName,
				AuthorId = post.User.Id,
				AuthorRating = post.User.Rating,
				DatePosted = post.Created.ToString(),
				RepliesCount=post.Reply.Count(),
				Forum=GetForumListingForPost(post)
			});
			return new HomeIndexModel
			{
				LatestPosts = posts,
				SearchQuery=""

			};
		}

		private ForumListingModel GetForumListingForPost(post post)
		{
			var forum = post.Forum;
			return new ForumListingModel
			{
				Id = forum.Id,
				Name = forum.Title,
				ImageUrl = forum.ImageUrl

			};
		}

		public IActionResult About()
		{
			ViewData["Message"] = "Your application description page.";

			return View();
		}

		public IActionResult Contact()
		{
			ViewData["Message"] = "Your contact page.";

			return View();
		}

		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}

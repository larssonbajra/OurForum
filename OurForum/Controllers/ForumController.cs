﻿using Microsoft.AspNetCore.Mvc;
using OurForum.Data.Interface;
using OurForum.Data.Models;
using OurForum.Models.Forum;
using System.Collections.Generic;
using System.Linq;

namespace OurForum.Controllers
{
	public class ForumController : Controller
    {
		private readonly IForum _forumService;
		public ForumController(IForum forumService)
		{
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
			var posts = _postService.FetFilteredPosts()
			return View();
		}
    }
}
using ArchitectureProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ArchitectureProject.Controllers
{
	public class BlogController : Controller
	{
		ArchitectureDbEntities dbEntities = new ArchitectureDbEntities();
		[AllowAnonymous]
		public ActionResult Index()
		{
			var values = dbEntities.Blog.OrderByDescending(x => x.DateBlog).Where(x => x.Status == true).ToList();
			return View(values);
		}
		[AllowAnonymous]
		public ActionResult BlogDetail(int id)
		{
			var values = dbEntities.Blog.ToList().Where(x => x.BlogID == id).ToList();
			return View(values);
		}
		[AllowAnonymous]
		public PartialViewResult BlogBottomSlider()
		{
			var values = dbEntities.Services.ToList();
			return PartialView(values);
		}
		public ActionResult ABlogList()
		{
			var values = dbEntities.Blog.OrderByDescending(x => x.DateBlog).ToList();
			return View(values);
		}
		[HttpGet]
		public ActionResult ANewBlog()
		{
			return View();
		}
		[HttpPost]
		public ActionResult ANewBlog(Blog blog)
		{
			blog.DateBlog = DateTime.Now;
			dbEntities.Blog.Add(blog);
			dbEntities.SaveChanges();
			return RedirectToAction("ABlogList");
		}
		public ActionResult ADeleteBlog(int id)
		{
			var blogInfo = dbEntities.Blog.ToList().Find(x => x.BlogID == id);
			dbEntities.Blog.Remove(blogInfo);
			dbEntities.SaveChanges();
			return RedirectToAction("ABlogList");
		}
		[HttpGet]
		public ActionResult AUpdateBlog(int id)
		{
			var blogInfo = dbEntities.Blog.ToList().Find(x => x.BlogID == id);
			return View(blogInfo);
		}
		[HttpPost]
		public ActionResult AUpdateBlog(Blog blog)
		{
			var blogInfo = dbEntities.Blog.ToList().Find(x => x.BlogID == blog.BlogID);
			blogInfo.Author = blog.Author;
			blogInfo.Content = blog.Content;
			blogInfo.Image = blog.Image;
			blogInfo.Title = blog.Title;
			dbEntities.SaveChanges();
			return RedirectToAction("ABlogList");
		}
		public ActionResult AStatusChangeBlog(int id)
		{
			var blogInfo = dbEntities.Blog.ToList().Find(x => x.BlogID == id);
			blogInfo.Status = !blogInfo.Status;
			dbEntities.SaveChanges();
			return RedirectToAction("ABlogList");
		}
	}
}
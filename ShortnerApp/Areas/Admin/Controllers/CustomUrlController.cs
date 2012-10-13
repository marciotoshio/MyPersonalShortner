using MyPersonalShortner.Lib.Domain.Repositories;
using MyPersonalShortner.Lib.Domain.Url;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyPersonalShortner.ShortnerApp.Areas.Admin.Controllers
{
	[Authorize]
	public class CustomUrlController : Controller
	{
		private ICustomUrlRepository repo;
		public CustomUrlController(ICustomUrlRepository repo)
		{
			this.repo = repo;
		}

		public ActionResult Index()
		{
			var customUrls = repo.GetAll();
			return View(customUrls);
		}

		public ActionResult Create()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Create(CustomUrl customUrl)
		{
			try
			{
				repo.Add(customUrl);
				repo.Save();
				return RedirectToAction("Index");
			}
			catch
			{
				return View(customUrl);
			}
		}

		public ActionResult Delete(int id)
		{
			var customUrl = repo.GetById(id);
			return View(customUrl);
		}

		[HttpPost]
		public ActionResult Delete(int id, CustomUrl customUrl)
		{
			try
			{
				repo.Remove(id);
				repo.Save();
				return RedirectToAction("Index");
			}
			catch
			{
				return View();
			}
		}
	}
}

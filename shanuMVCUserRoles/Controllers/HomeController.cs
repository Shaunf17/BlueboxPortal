using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using shanuMVCUserRoles.Models;

namespace shanuMVCUserRoles.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
            var userRole = User.Identity.AuthenticationType;
            ViewBag.UserName = User.IsInRole("Admin");
			return View();
		}

		public ActionResult About()
		{
			ViewBag.Message = "Your application description page.";

			return View();
		}

		public ActionResult Contact()
		{
			ViewBag.Message = "Your contact page.";

			return View();
		}
	}
}
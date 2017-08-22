﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using BlueboxPortal.Models;

namespace BlueboxPortal.Controllers
{
	public class HomeController : Controller
	{
		public ActionResult Index()
		{
            var pdbm = new PortalDBModel();
            pdbm.populateServiceRuns();
            var temp = pdbm.Airlines.First().FriendlyName;
            var temp2 = pdbm.ServiceRuns.First().airline.FriendlyName;

            var airlineService = pdbm.getServiceRunForAirline(pdbm.Airlines.First());

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
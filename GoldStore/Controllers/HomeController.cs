﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoldStore.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "About - GoldStore.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "GoldStore contact.";

            return View();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace TeamProjectWeb.Controllers.MVC
{
    public class HomeController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Welcome to Light Project Tracking ";
            ViewData["Message"] = "The easiest way to manage your next project";

            return View();
        }

     
    }
}
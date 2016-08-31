using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StandartApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var firstVal = 10;
            var secondVal = 5;

            var result = firstVal / secondVal;

            ViewBag.Message = "Отладка приложения ASP.NET MVC";

            return View(result);
        }
    }
}
using PartyInvites.Models;
using System;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            var hour = DateTime.Now.Hour;
            ViewBag.Greeting = hour > 12 ? "Доброго дня" : "Доброго утра";

            return View();
        }

        [HttpGet]
        public ViewResult RcvpForm()
        {
            return View();
        }

        [HttpPost]
        public ViewResult RcvpForm(GuestResponse guest)
        {
            if(ModelState.IsValid)
            {
                return View("Thanks", guest);
            }
            else
            {
                return View();
            }
        }
    }
}
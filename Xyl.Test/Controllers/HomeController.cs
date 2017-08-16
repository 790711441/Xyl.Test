using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Xyl.Test.Code.Expand;

namespace Xyl.Test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var user = this.GetUser();
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
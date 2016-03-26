using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;

namespace Wishlist.Controllers
{
    [Route("")]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index() {
            ViewBag.Foo = "Foobar";
            return View();
        }
    }
}
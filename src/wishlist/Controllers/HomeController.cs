using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;

namespace Wishlist.Controllers
{
    [Route("")]
	[Authorize]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index() {
            return View();
        }
    }
}
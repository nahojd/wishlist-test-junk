using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Authorization;
using Microsoft.AspNet.Mvc;
using Wishlist.Model;

namespace Wishlist.Controllers
{
    [Route("")]
	[Authorize]
    public class HomeController : Controller
    {
        private readonly IUserRepository userRepository;

        public HomeController(IUserRepository userRepository) {
            this.userRepository = userRepository;
        }
        
        [HttpGet]
        public async Task<ActionResult> Index() {
            var appState = new AppState {
                Name = User.Identity.Name,
                Friends = userRepository.GetFriends(this.User.Identity.Name)
            };
            
            return View("Index", appState);
        }
    }
    
    public class AppState {
        public string Name { get; set; }
        public IEnumerable<string> Friends { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Authorization;
using Wishlist.Model;

namespace Wishlist.Controllers
{
    [Authorize]
    [Route("api/users")]
    public class UsersController : Controller
    {
        private readonly IUserRepository repository;
        
        public UsersController(IUserRepository repository) {
            this.repository = repository;
        }
        
        [HttpGet("")]
        public IEnumerable<string> GetAllUsers() {
            return repository.GetAllUsers();
        }
        
        [HttpGet("{username}/friends")]
        public IEnumerable<string> GetFriends(string username) {
            return repository.GetFriends(username);
        }
        
        
    }
}

using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.AspNet.Mvc;
using Wishlist.Model;

[Route("account")]
public class AccountController : Controller
{
    private readonly IUserRepository repository;
    
    public AccountController(IUserRepository repository) {
        this.repository = repository;
    }
    
	[HttpGet("login")]
	public ActionResult Login(string returnUrl = null) {
		ViewBag.ReturnUrl = returnUrl;
		return View();
	}
	
	[HttpPost("login")]
	public async Task<ActionResult> Login(string username, string password, string returnUrl = null) {
		
        if (!repository.AuthenticateUser(username, password)) {
            ViewBag.ReturnUrl = returnUrl;
            ViewBag.Error = "Felaktigt användarnamn eller lösenord, var god försök igen.";
            return View();
        }
        
        const string Issuer = "https://wishlist.local";
		var claims = new List<Claim>();
		claims.Add(new Claim(ClaimTypes.Name, username, ClaimValueTypes.String, Issuer));
		var userIdentity = new ClaimsIdentity("SuperSecureLogin");
		userIdentity.AddClaims(claims);
		var userPrincipal = new ClaimsPrincipal(userIdentity);

		await HttpContext.Authentication.SignInAsync("Cookie", userPrincipal,
			new AuthenticationProperties
			{
				ExpiresUtc = DateTime.UtcNow.AddMinutes(20),
				IsPersistent = false,
				AllowRefresh = false
			});
			
		if (returnUrl != null)
			return Redirect(returnUrl);
		
		return RedirectToAction("Index", "Home");
	}
    
    [HttpGet("logout")]
    public async Task<ActionResult> Logout() {
        await HttpContext.Authentication.SignOutAsync("Cookie", null);
        
        return RedirectToAction("Login");
    }
}
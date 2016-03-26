using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Http.Authentication;
using Microsoft.AspNet.Mvc;

[Route("account")]
public class AccountController : Controller
{
	[HttpGet]
	[Route("login")]
	public ActionResult Login(string returnUrl = null) {
		ViewBag.ReturnUrl = returnUrl;
		return View();
	}
	
	[HttpPost]
	[Route("login")]
	public async Task<ActionResult> Login(string username, string password, string returnUrl = null) {
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
}
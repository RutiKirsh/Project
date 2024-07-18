//using Microsoft.AspNetCore.Authentication;
//using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Authentication.Google;
//using Microsoft.AspNetCore.Mvc;
//using System.Threading.Tasks;

//namespace Server.Controllers;
//public class AccountController : Controller
//{
//    [HttpGet("signin-google")]
//    public IActionResult SignInGoogle()
//    {
//        var properties = new AuthenticationProperties { RedirectUri = Url.Action("GoogleResponse") };
//        return Challenge(properties, GoogleDefaults.AuthenticationScheme);
//    }

//    [HttpGet("google-response")]
//    public async Task<IActionResult> GoogleResponse()
//    {
//        var result = await HttpContext.AuthenticateAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//        var claims = result.Principal.Identities.FirstOrDefault().Claims.Select(claim => new
//        {
//            claim.Issuer,
//            claim.OriginalIssuer,
//            claim.Type,
//            claim.Value
//        });

//        return Json(claims);
//    }

//    [HttpPost("logout")]
//    public async Task<IActionResult> Logout()
//    {
//        await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
//        return RedirectToAction("Index", "Home");
//    }
//}

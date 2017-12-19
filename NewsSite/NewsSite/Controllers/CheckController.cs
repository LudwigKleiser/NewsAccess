using NewsSite.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace NewsSite.Controllers
{

    [Route("check")]
    public class CheckController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public CheckController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet, Route("view/OpenNews")]
        public IActionResult ViewOpenNews()
        {
            return Ok();
        }

        // TODO: Skapa en Policy i Startup.cs och avkommentera sedan nedan
        // Controllern behöver inte innehålla någon mer kod

        //[Authorize(Policy = "HiddenNews")]
        //[HttpGet, Route("view/HiddenNews")]
        //public IActionResult ViewHiddenNews()
        //{
        //    return Ok();
        //}

    }
}

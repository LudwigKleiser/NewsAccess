using NewsSite.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace NewsSite.Controllers
{

    [Route("check")]
    public class CheckController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public CheckController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet, Route("view/OpenNews")]
        public IActionResult ViewOpenNews()
        {
            return Ok();
        }

       [Authorize(Policy = "PublishSport")]
       [HttpGet, Route("Sport")]
       public IActionResult Sport()
        {
            return Ok("True");
        }

        [Authorize(Policy = "PublishCulture")]
        [HttpGet, Route("Culture")]
        public IActionResult Culture()
        {
            return Ok("True");
        }

        [AllowAnonymous]
        [HttpGet, Route("OpenNews")]
        public IActionResult OpenNews()
        {
            return Ok("true");
        }


        [HttpGet, Route("view/get")]
        async public Task<IActionResult> Get()
        {
            var result = await _userManager.FindByEmailAsync("ludde@hotmail.com");
            return Ok(result.Email);
        }
        

       [Authorize(Policy = "HiddenNews")]
        [HttpGet, Route("HiddenNews")]
        public IActionResult HiddenNews()
        {
            return Ok("True");
        }

        [Authorize(Policy = "HiddenNews")]
        [Authorize(Policy = "IsOfAge")]
        [HttpGet, Route("HiddenAgeNews")]
        public IActionResult HiddenAgeNews()
        {
            return Ok("True");
        }

    }
}

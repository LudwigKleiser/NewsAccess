using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NewsSite.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace NewsSite.Controllers
{
    [Route("user")]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private ApplicationDbContext _applicationDbContext;
        public ApplicationDbContext ApplicationDbContext { get; }

        public UserController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _applicationDbContext = applicationDbContext;

        }

        [HttpGet,Route("UsersAndClaims")]

        [HttpGet, Route("Empty")]
        async public Task<IActionResult> EmptyDatabase()
        {
            _applicationDbContext.EmptyDatabase();

            var result = await Add();

            return Ok(result);
        }

        [HttpGet, Route("login")]
        async public Task<IActionResult> LogIn(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            await _signInManager.SignInAsync(user, true);
            return Ok(user.Email);
        }

        [HttpGet, Route("Add")]
        async public Task<IActionResult> Add()
        {

            await _roleManager.CreateAsync(new IdentityRole("Admin"));
            await _roleManager.CreateAsync(new IdentityRole("Publisher"));
            await _roleManager.CreateAsync(new IdentityRole("Subscriber"));
            //_applicationDbContext.EmptyDatabase();
            string[] users = { "adam@gmail.com", "", "Admin",
                "peter@gmail.com", "", "Publisher",
                "susan@gmail.com", "48", "Subscriber",
                "viktor@gmail.com", "15", "Subscriber",
                 "xerxes@gmail.com", "", ""};

            for (int i = 0; i < users.Length; i += 3)
            {
                ApplicationUser newUser = new ApplicationUser
                {
                    Email = users[i],
                    UserName = users[i]
                };
                if (users[i + 1] != "") newUser.Age = int.Parse(users[i + 1]);

                var resultNewUser = await _userManager.CreateAsync(newUser);
                if (resultNewUser.Succeeded && users[i + 2] != "") await _userManager.AddToRoleAsync(newUser, users[i + 2]);
                if ((await _userManager.GetRolesAsync(newUser)).Contains("Admin")
                    || (await _userManager.GetRolesAsync(newUser)).Contains("Publisher")
                    || (newUser.Age != null && newUser.Age >= 20))
                    await _userManager.AddClaimAsync(newUser, new Claim("MinimumAge", "True"));
                   
                if((await _userManager.GetRolesAsync(newUser)).Contains("Admin"))
                {
                    await _userManager.AddClaimAsync(newUser, new Claim("Sports", "true"));
                    await _userManager.AddClaimAsync(newUser, new Claim("Culture", "true"));
                    await _userManager.AddClaimAsync(newUser, new Claim("Economy", "true"));
                }

                if ((await _userManager.GetRolesAsync(newUser)).Contains("Publisher"))
                {
                    await _userManager.AddClaimAsync(newUser, new Claim("Sports", "true"));
                    await _userManager.AddClaimAsync(newUser, new Claim("Economy", "true"));
                }


            }

            return Ok(_userManager.Users);
        }


        [Authorize(Policy = "isOfAge")]
        [HttpGet, Route("test")]
        public IActionResult Test()
        {
            return Ok("Yes");
        }
        async public Task<IActionResult> AddClaim()
        {

            var user = await _userManager.FindByEmailAsync("hej2");

            var result = await _userManager.AddClaimAsync(user, new Claim("ShoeSize", "42"));

            return Ok("hej");
        }
        [HttpGet, Route("Role")]
        async public Task<IActionResult> Role()
        {
            var user = await _userManager.FindByEmailAsync("adam@gmail.com");
            //await _userManager.AddToRoleAsync(user, "Publisher");
            return Ok(await _userManager.GetRolesAsync(user));


        }
    }
}

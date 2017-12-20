using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Security.Claims;

namespace NewsSite.Data
{
    public class ApplicationUser : IdentityUser
    {
        public int? Age { get; set; }
       
    }
}
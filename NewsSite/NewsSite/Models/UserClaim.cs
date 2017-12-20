using NewsSite.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NewsSite.Models
{
    public class UserClaim
    {
        //public string Id { get; set; }
        //public int AccessFailedCount { get; set; }
        //public int ?Age { get; set; }
        //public string ConcurrencyStamp { get; set; }
        //public string Email { get; set; }
        //public bool EmailConfirmed { get; set; }
        //public bool LockoutEnabled { get; set; }
        //public DateTimeOffset? LockoutEnd { get; set; }
        //public string NormalizedEmail { get; set; }
        //public string NormalizedUserName { get; set; }
        //public string PasswordHash { get; set; }

        //public string PhoneNumber { get; set; }
        //public bool PhoneNumberConfirmed { get; set; }
        //public string SecurityStamp { get; set; }
        //public bool TwoFactorEnabled { get; set; }
        //public string UserName { get; set; }

        public ApplicationUser User { get; set; }

        public IList<Claim> Claims { get; set; }




    }
}

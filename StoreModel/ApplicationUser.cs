using Microsoft.AspNet.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StoreModel
{
    public class ApplicationUser : IdentityUser
    {
        public virtual Customer Customer { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}

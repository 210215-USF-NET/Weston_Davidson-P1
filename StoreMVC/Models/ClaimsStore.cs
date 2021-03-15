using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    public static class ClaimsStore
    {
        public static Claim Employee = new Claim("Employee", "Employee");


    }
}

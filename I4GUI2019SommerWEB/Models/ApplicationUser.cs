using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace I4GUI2019SommerWEB.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string EmployeeNumber { get; set; }

        public string Company { get; set; }
        
        public override string Email { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }
    }

}

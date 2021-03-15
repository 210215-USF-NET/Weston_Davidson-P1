using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace StoreMVC.Models
{
    public class User
    {
        [DisplayName("First Name")]
        [Required]
        public string FName { get; set; }
        [DisplayName("Last Name")]
        [Required]
        public string LName { get; set; }
        [DisplayName("Email Address")]
        [Required]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }
        [DisplayName("Location")]
        public string Location { get; set; }
        [DisplayName("User Password")]
        [Required]
        public string Password { get; set; }
    }
}

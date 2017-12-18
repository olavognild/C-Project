using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Dating.Models
{
    public class EditAccount
    {

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }



        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [StringLength(750, ErrorMessage = "rip 750 characters")]
        [Display(Name = "Tell us something about you")]
        public string About { get; set; }
    }
}
using BugTracker.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        //a property that validates if the email is already in use on the
        //client-side not on server
        [Remote(action: "IsEmailInUse", controller: "Account")]
        //this method allows the user to only use these domain names
        [ValidEmailDomain(allowedDomain: "hotmail.com",
            allowedDomain1: "gmail.com",
            allowedDomain2: "yahoo.com",
            allowedDomain3: "live.com"
            )]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }

        [Display(Name = "Name of Organization")]
        public string NameOfOrganization { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HerbsStore.Models
{
    public class RegisterVm
    {
        [Required, EmailAddress, MaxLength(256), Display(Name = "Email Address", Description = "Email address")]
        public string EmailAddress { get; set; }

        [Required, MaxLength(256), Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required, MaxLength(256), Display(Name = "Last name")]
        public string LastName { get; set; }

         [Required, MaxLength(256), Display(Name = "Address")]
        public string Address { get; set; }


         [Required, MaxLength(256), Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

      
        public bool AgreeToTermsAndConditions { get; set; }

        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Password")]
        public string Password { get; set; }

        [Required, MinLength(6), MaxLength(50), DataType(DataType.Password), Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The password does not match the confirmation password.")]
        public string ConfirmPassword { get; set; }

    }
}

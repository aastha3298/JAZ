using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JAZ.Models.ViewModel
{
  
        public class LoginViewModel
        {
            [Required]
            [Display(Name = "Email")]
            [EmailAddress]
            public string Email { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }
            [Display(Name = "Remember Me")]
            public bool RememberMe { get; set; }


    }

        public class RegisterViewModel
        {
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Required]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string ConfirmPassword { get; set; }
            [Required]
            [StringLength(30, ErrorMessage = "Length should be less than 30")]
            public string CustomerName { get; set; }
            [Required]
            [StringLength(50, ErrorMessage = "Length should be less than 50")]
            public string Address { get; set; }
            [Required]
            [StringLength(20, ErrorMessage = "Length should be less than 20")]
            public string Country { get; set; }
            [Required]
            [StringLength(20, ErrorMessage = "Length should be less than 20")]
            public string Province { get; set; }
            [Required]
            [StringLength(20, ErrorMessage = "Length should be less than 20")]
            public string City { get; set; }

            [Required(ErrorMessage = "Field is mandatory")]
            [RegularExpression(@"^[0-9]{6}$", ErrorMessage = "Pin code must of 6 digit ")]
            public int PostalCode { get; set; }




            [Required(ErrorMessage = "Field is mandatory")]
            [RegularExpression(@"^(\d{10})$",
    ErrorMessage = "Enter a valid 10 digit number")]
            public Int64 ContactNo { get; set; }

        }
    }

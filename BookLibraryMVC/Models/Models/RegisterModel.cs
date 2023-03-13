﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace BookLibraryMVC.Models.Models
{
    public class RegisterModel
    {
        [Required]
        [MaxLength(15)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(15)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(25)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [PasswordPropertyText]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [PasswordPropertyText]
        [StringLength(20, MinimumLength = 6)]
        [Compare("Password", ErrorMessage = "Confirm password doesn't match, Type again !")]
        public string ConfirmPassword { get; set; }
    }
}

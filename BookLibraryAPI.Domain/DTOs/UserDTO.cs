using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Text;

namespace BookLibraryAPI.Domain.DTOs
{
    public class UserDTO
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

    }
}

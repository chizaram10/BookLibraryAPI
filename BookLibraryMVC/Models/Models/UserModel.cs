using System.ComponentModel.DataAnnotations;

namespace BookLibraryMVC.Models.Models
{
    public class UserModel
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

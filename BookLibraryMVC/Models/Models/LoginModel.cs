using System.ComponentModel.DataAnnotations;

namespace BookLibraryMVC.Models.Models
{
    public class LoginModel
    {
        [Required]
        [EmailAddress]
        [MaxLength(50)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;

namespace BookLibraryMVC.Models.Models
{
    public class ReviewModel
    {
        [Required]
        [StringLength(500)]
        public string Message { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

		public string Date { get; } = DateTime.Now.ToString("dd mmmm yyyy");

		[Required]
        public int BookID { get; set; }
    }
}

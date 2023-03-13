using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookLibraryAPI.Domain.DTOs
{
    public class ReviewModel
    {
        [Required]
        [StringLength(150)]
        public string Message { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Date { get;} = DateTime.Now.ToString("dd mmmm yyyy");
    }
}

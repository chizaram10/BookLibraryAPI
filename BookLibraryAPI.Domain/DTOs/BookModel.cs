using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using BookLibraryAPI.Domain.Enums;

namespace BookLibraryAPI.Domain.DTOs
{
    public class BookModel
    {
        [Required]
        [StringLength(20)]
        public string Title { get; set; }
        [Required]
        [MaxLength(150)]
        public string Description { get; set; }
        [Required]
        [StringLength(4)]
        public int Year { get; set; }
        [Required]
        [StringLength(14, MinimumLength =10)]
        public string ISBN { get; set; }
        [Required]
        public int NumberOfCopies { get; set; }
        [Required]
        [StringLength(20)]
        public string Author { get; set; }
        [Required]
        [StringLength(20)]
        public string Publisher { get; set; }
        [Required]
        [Url]
        public string ImageUrl { get; set; }
        [Required]
        public Genre Genre { get; set; }
        public string BookGenre => Genre.ToString();
        public int BookId { get; set; }
    }
}

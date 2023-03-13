using BookLibraryAPI.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookLibraryAPI.Domain.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Year { get; set; }
        public string ISBN { get; set; }
        public bool IsAvaliable { get; set; }
        public int NumberOfCopies { get; set; }
        public int CheckOuts { get; set; }
        public bool IsPopular { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ImageUrl { get; set; }
        public Genre Genre { get; set; }

        public List<Review> BookReviews { get; set; }
    }
}

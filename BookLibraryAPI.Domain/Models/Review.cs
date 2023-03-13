using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace BookLibraryAPI.Domain.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string Message { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public int BookId { get; set; }

        [ForeignKey("BookId")]
        public Book Book { get; set; }



    }
}

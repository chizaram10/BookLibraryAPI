using BookLibraryMVC.Models.Models;
using System.Collections.Generic;

namespace BookLibraryMVC.ViewModels
{
    public class DetailsViewModel
    {
        public BookModel Book { get; set; }
        public IEnumerable<ReviewModel> Reviews { get; set; }
    }
}

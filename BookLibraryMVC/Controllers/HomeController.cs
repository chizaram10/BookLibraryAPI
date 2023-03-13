using BookLibraryMVC.Models.Models;
using BookLibraryMVC.Services.Abstractions;
using BookLibraryMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookService _bookService;
        private readonly IReviewService _reviewService;

        public HomeController(ILogger<HomeController> logger, IBookService bookService,
			IReviewService reviewService)
        {
            _logger = logger;
            _bookService = bookService;
            _reviewService = reviewService;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<BookModel> books = new List<BookModel>();
            var result = await _bookService.GetAllBooksAsync();
            books = result;
            return View(books);
        }

        public async Task<IActionResult> Details(int id)
        {
            DetailsViewModel detailsViewModel = new DetailsViewModel();
            var result1 = await _bookService.GetBookByIdAsync(id);
			if (result1 == null) return NotFound();
			var result2 = await _reviewService.GetAllBookReviews(id);
            detailsViewModel.Book = result1;
            detailsViewModel.Reviews = result2;
            return View(detailsViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

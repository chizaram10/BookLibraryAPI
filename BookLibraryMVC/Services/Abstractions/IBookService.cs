using BookLibraryMVC.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibraryMVC.Services.Abstractions
{
    public interface IBookService
    {
        Task<IEnumerable<BookModel>> GetAllBooksAsync();

        Task<BookModel> GetBookByIdAsync(int bookId);

        Task<ResponseModel> UpdateBookAsync(BookModel bookViewModel, int bookId);

        Task<ResponseModel> DeleteBookAsync(int bookId);
    }
}

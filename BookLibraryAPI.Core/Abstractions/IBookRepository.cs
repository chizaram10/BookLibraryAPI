using BookLibraryAPI.Domain.DTOs;
using BookLibraryAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryAPI.Core.Abstractions
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllBooks();
        Task<Book> GetBookByBookId(int bookId);
        Task<Book> AddBook(BookModel model);
        Task<Book> UpdateBook(BookModel model, int bookId);
        Task<Book> DeleteBook(int id);
    }
}

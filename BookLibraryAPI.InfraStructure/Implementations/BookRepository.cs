using BookLibraryAPI.Core.Abstractions;
using BookLibraryAPI.Domain.DTOs;
using BookLibraryAPI.Domain.Models;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookLibraryAPI.InfraStructure.Implementations
{
    public class BookRepository : IBookRepository
    {
        private readonly BookLibraryContext _context;

        public BookRepository(BookLibraryContext context)
        {
            _context = context;
        }

		public async Task<IEnumerable<Book>> GetAllBooks()
		{
			await using (_context)
			{
				return await _context.Books.ToListAsync();
			}
		}

		public async Task<Book> GetBookByBookId(int bookId)
		{
			Book book = null;
			var allBooks = await GetAllBooks();
			if (allBooks != null && allBooks.Count() != 0)
			{
				foreach (var b in allBooks)
				{
					if (b.BookId == bookId)
						book = b;
				}
			}
			return book;
		}

		public async Task<Book> AddBook(BookModel model)
		{
			
			var allBooks = await GetAllBooks();

			Book book = new Book
			{
				Title = model.Title,
				ImageUrl = model.ImageUrl,
				ISBN = model.ISBN,
				Publisher = model.Publisher,
				Author = model.Author,
				NumberOfCopies = model.NumberOfCopies,
				Year = model.Year,
				Description = model.Description,
			};

			foreach (var b in allBooks.ToList())
			{
				if (b.ISBN == book.ISBN) return null;
			}
			
			try
			{
				await using (_context)
				{
					var result = await _context.Books.AddAsync(book);
					await _context.SaveChangesAsync();
					return result.Entity;
				}
			}

			catch (Exception) { return null; }
		}

		public async Task<Book> UpdateBook(BookModel model, int bookId)
		{
			var book = await GetBookByBookId(bookId);

			if (book != null)
			{
				book.Title = model.Title;
				book.ImageUrl = model.ImageUrl;
				book.ISBN = model.ISBN;
				book.Publisher = model.Publisher;
				book.Author = model.Author;
				book.NumberOfCopies = model.NumberOfCopies;
				book.Year = model.Year;
				book.Description = model.Description;

				try
				{
					await using (_context)
					{
						_context.Books.Update(book);
						await _context.SaveChangesAsync();
						return book;
					}
				}
				catch (Exception) { return null; }
			}

			return null;
		}

		public async Task<Book> DeleteBook(int id)
        {
            var allBooks = await GetAllBooks();
            var bookToRemove = allBooks.FirstOrDefault(b => b.BookId == id);

            if (bookToRemove == null) return null;

            try
            {
                await using (_context)
                {
                    _context.Books.RemoveRange(bookToRemove);
                    await _context.SaveChangesAsync();
					return bookToRemove;
                }
            }
            catch (Exception) { return null; }
        }
    }
}

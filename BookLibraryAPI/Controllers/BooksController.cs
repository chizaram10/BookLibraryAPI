using BookLibraryAPI.Core.Abstractions;
using BookLibraryAPI.Domain.DTOs;
using BookLibraryAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
		{
			try
			{
                var result = await _bookRepository.GetAllBooks();
				return result.ToList();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error retrieving data from the database");
			}
		}

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id)
		{
            var result = await _bookRepository.GetBookByBookId(id);
            if (result == null) return NotFound();

            return result;
        }

        [HttpPost]
        public async Task<ActionResult<Book>> PostBook([FromBody]BookModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _bookRepository.AddBook(model);
				if (result != null) return Ok(result);

				return StatusCode(StatusCodes.Status500InternalServerError,
				"Error adding new book");
			}
            return BadRequest();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutBook([FromBody]BookModel model, int id)
        {
            if (ModelState.IsValid)
            {
                var result = await _bookRepository.UpdateBook(model, id);
                if (result == null) return NotFound();

                return NoContent();
			}
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
		{
            var result = await _bookRepository.DeleteBook(id);
            if (result == null) return NotFound();

            return Ok(result);
        }
    }
}

using BookLibraryAPI.Core.Abstractions;
using BookLibraryAPI.Domain.DTOs;
using BookLibraryAPI.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
		private readonly IReviewRepository _reviewRepository;

		public ReviewsController(IReviewRepository reviewRepository)
		{
			_reviewRepository = reviewRepository;
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Review>>> GetBookReviews()
		{
			var result = await _reviewRepository.GetAllReviews();

			return result.ToList();
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Review>> GetBookReview(int id)
		{
			var result = await _reviewRepository.GetReviewsByReviewId(id);
			if (result == null) return NotFound();

			return result;
		}

		[HttpPost("{id}")]
		//[Authorize (Roles = "Regular")]
		public async Task<ActionResult<Review>> PostBookReviews(ReviewModel model, int id)
		{
			if (ModelState.IsValid)
			{
				var result = await _reviewRepository.AddReview(model, id);
				if (result == null) return StatusCode(StatusCodes.Status500InternalServerError,
				"Error adding new review");

				return Ok(result);
			}
			return BadRequest();
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> PutReview([FromBody] ReviewModel model, int id)
		{
			if (ModelState.IsValid)
			{
				var result = await _reviewRepository.UpdateReview(model, id);
				if (result == null) return NotFound();

				return NoContent();
			}
			return BadRequest();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult<Review>> DeleteReview(int id)
		{
			var result = await _reviewRepository.DeleteReview(id);
			if (result == null) return NotFound();

			return Ok(result);
		}
	}
}

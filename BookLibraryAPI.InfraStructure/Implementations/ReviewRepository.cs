using BookLibraryAPI.Core.Abstractions;
using BookLibraryAPI.Domain.DTOs;
using BookLibraryAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryAPI.InfraStructure.Implementations
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly BookLibraryContext _context;

        public ReviewRepository(BookLibraryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Review>> GetAllReviews()
        {
            await using (_context)
            {
                var allReviews = await _context.Reviews.ToListAsync();
                return allReviews;
            }
        }

        public async Task<IEnumerable<Review>> GetBookReviews(int bookId)
        {
            var allReviews = await GetAllReviews();

            if(allReviews != null && allReviews.Any()) 
                return allReviews.Where(r => r.BookId == bookId).ToList();

            return null;
        }

        public async Task<Review> GetReviewsByReviewId(int reviewId)
        {
            Review review = null;
			var allReviews = await GetAllReviews();
			if (allReviews != null && allReviews.Count() != 0)
			{
				foreach (var r in allReviews)
				{
					if (r.ReviewId == reviewId)
						review = r;
				}
			}
			return review;
		}

        public async Task<Review> AddReview(ReviewModel model, int bookID)
        {
			Review review = new Review
			{
				Name = model.Name,
				Message = model.Message,
				Date = DateTime.Now.ToString("dd MMMM yyyyy"),
				BookId = bookID
			};

			try
			{
				await using (_context)
				{
					var result = _context.Reviews.Add(review);
					_context.SaveChanges();
					return result.Entity;
				}
			}
			catch (Exception) { return null; } 
        }

		public async Task<Review> UpdateReview(ReviewModel model, int reviewId)
		{
			var review = await GetReviewsByReviewId(reviewId);

			if (review != null)
			{
				review.Message = model.Message;
				review.Date = model.Date;
				review.Name = model.Name;

				try
				{
					await using (_context)
					{
						var result = _context.Reviews.Update(review);
						await _context.SaveChangesAsync();
                        return result.Entity;
					}
				}
				catch (Exception) { return null; }
			}

			return null;
		}

		public async Task<Review> DeleteReview(int id)
		{
			var allReviews = await GetAllReviews();
			var reviewsToRemove = allReviews.FirstOrDefault(r => r.ReviewId == id);
			if (reviewsToRemove == null) return null;
			try
			{
				await using (_context)
				{
					var result = _context.Reviews.Remove(reviewsToRemove);
					_context.SaveChanges();
					return result.Entity;
				}
			}
			catch (Exception) { return null; }
		}

	}
}

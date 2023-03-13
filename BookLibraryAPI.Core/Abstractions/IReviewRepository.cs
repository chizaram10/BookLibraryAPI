using BookLibraryAPI.Domain.DTOs;
using BookLibraryAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryAPI.Core.Abstractions
{
    public interface IReviewRepository
    {
        Task<IEnumerable<Review>> GetAllReviews();

        Task<IEnumerable<Review>> GetBookReviews(int bookId);

        Task<Review> GetReviewsByReviewId(int reviewId);

        Task<Review> AddReview(ReviewModel model, int bookId);

        Task<Review> UpdateReview(ReviewModel model, int reviewId);

        Task<Review> DeleteReview(int id);
    }
}

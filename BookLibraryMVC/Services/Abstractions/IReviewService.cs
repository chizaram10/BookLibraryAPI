using BookLibraryMVC.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BookLibraryMVC.Services.Abstractions
{
    public interface IReviewService
    {
        Task<IEnumerable<ReviewModel>> GetAllBookReviews(int bookId);

        Task<ResponseModel> UploadReviews(ReviewModel model, int bookId);
    }
}

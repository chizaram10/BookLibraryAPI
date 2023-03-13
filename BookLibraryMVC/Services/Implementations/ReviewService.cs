using BookLibraryMVC.Helpers;
using BookLibraryMVC.Models.Models;
using BookLibraryMVC.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookLibraryMVC.Services.Implementations
{
    public class ReviewService : IReviewService
    {
        private const string baseURL = "https://localhost:44345/api/Reviews";
        private readonly HttpClientHandler httpClientHandler = new HttpClientHandler();

        public ReviewService()
        {
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        public async Task<IEnumerable<ReviewModel>> GetAllBookReviews(int bookId)
        {
            List<ReviewModel> allBookReviews = new List<ReviewModel>();

            using (var client = new HttpClient(httpClientHandler))
            {
                using (var response = await client.GetAsync($"{baseURL}/{bookId}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<List<ReviewModel>>(apiResponse);

                    if (result != null) allBookReviews = result;

                    return allBookReviews;
                }
            }
        }

        public async Task<ResponseModel> UploadReviews(ReviewModel model, int bookId)
        {
            ResponseModel responseModel = new ResponseModel();
            using (var client = new HttpClient(httpClientHandler))
            {
                using (var response = await client.GetAsync($"{baseURL}/{bookId}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<ResponseModel>(apiResponse);

                    if (result != null) responseModel = result;

                    return responseModel;
                }
            }
        }
    }
}

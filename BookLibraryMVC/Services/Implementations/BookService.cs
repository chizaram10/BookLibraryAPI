using BookLibraryMVC.Helpers;
using BookLibraryMVC.Models.Models;
using BookLibraryMVC.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BookLibraryMVC.Services.Implementations
{
    public class BookService : IBookService
    {
        private const string baseURL = "https://localhost:44345/api/Books";
        private readonly HttpClientHandler httpClientHandler = new HttpClientHandler();

        public BookService()
        {
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        public async Task<ResponseModel> DeleteBookAsync(int bookId)
        {
            using (var client = new HttpClient(httpClientHandler))
            {
                using (var response = await client.GetAsync($"{baseURL}/{bookId}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<ResponseModel>(apiResponse);

                    return result;
                }
            }
        }

        public async Task<IEnumerable<BookModel>> GetAllBooksAsync()
        {
            List<BookModel> books = new List<BookModel>();

            using (var client = new HttpClient(httpClientHandler))
            {
                using (var response = await client.GetAsync(baseURL))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<List<BookModel>>(apiResponse);

                    if (result != null) books = result;

                    return books;
                }
            }
        }

        public async Task<BookModel> GetBookByIdAsync(int bookId)
        {
            BookModel book = new BookModel();

            using (var client = new HttpClient(httpClientHandler))
            {
                using (var response = await client.GetAsync($"{baseURL}/{bookId}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<BookModel>(apiResponse);

                    if (result != null) book = result;

                    return book;
                }
            }
        }

        public async Task<ResponseModel> UpdateBookAsync(BookModel bookViewModel, int bookId)
        {
            using (var client = new HttpClient(httpClientHandler))
            {
                using (var response = await client.GetAsync($"{baseURL}/{bookId}"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<ResponseModel>(apiResponse);

                    return result;
                }
            }
        }
    }
}

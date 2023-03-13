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
    public class UserService : IUserService
    {
        private const string baseURL = "https://localhost:44345/api/User";
        private readonly HttpClientHandler httpClientHandler = new HttpClientHandler();

        public UserService()
        {
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }

        public async Task<ResponseModel> DeleteUser(string email)
        {
            ResponseModel responseModel = new ResponseModel();
            using (var client = new HttpClient(httpClientHandler))
            {
                using (var response = await client.GetAsync(baseURL))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<ResponseModel>(apiResponse);

                    responseModel = result;

                    return responseModel;
                }
            }
        }

        public async Task<IEnumerable<UserModel>> GetAllUsers()
        {
            List <UserModel> allBookReviews = new List<UserModel>();

            using (var client = new HttpClient(httpClientHandler))
            {
                using (var response = await client.GetAsync(baseURL))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<List<UserModel>>(apiResponse);

                    if (result != null) allBookReviews = result;

                    return allBookReviews;
                }
            }
        }

        public async Task<ResponseModel> UpdateUserRole(string email)
        {
            ResponseModel responseModel = new ResponseModel();
            using (var client = new HttpClient(httpClientHandler))
            {
                using (var response = await client.GetAsync(baseURL))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<ResponseModel>(apiResponse);

                    responseModel = result;

                    return responseModel;
                }
            }
        }
    }
}

using BookLibraryMVC.Models.Models;
using BookLibraryMVC.Services.Abstractions;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookLibraryMVC.Helpers;
using System.Runtime.CompilerServices;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;

namespace BookLibraryMVC.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private const string baseURL = "https://localhost:44345/api/Auth";
        private readonly HttpClientHandler httpClientHandler = new HttpClientHandler();

        public AuthService()
        {
            httpClientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
        }
        public async Task<ResponseModel> Login(LoginModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            using (var client = new HttpClient(httpClientHandler))
            {
                using (var response = await client.GetAsync($"{baseURL}/login"))
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();

                    var result = JsonConvert.DeserializeObject<ResponseModel>(apiResponse);

                    responseModel = result;

                    return responseModel;
                }
            }
        }

        public async Task<ResponseModel> Register(RegisterModel model)
        {
            ResponseModel responseModel = new ResponseModel();
            using (var client = new HttpClient(httpClientHandler))
            {
                using (var response = await client.GetAsync($"{baseURL}/register"))
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

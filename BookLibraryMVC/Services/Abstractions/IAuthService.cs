using BookLibraryMVC.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BookLibraryMVC.Services.Abstractions
{
    public interface IAuthService
    {
        Task<ResponseModel> Login(LoginModel model);
        Task<ResponseModel> Register(RegisterModel model);
    }
}

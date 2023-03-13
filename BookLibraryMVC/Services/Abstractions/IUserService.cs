using BookLibraryMVC.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibraryMVC.Services.Abstractions
{
    public interface IUserService
    {
        Task<ResponseModel> UpdateUserRole(string email);
        Task<ResponseModel> DeleteUser(string email);
        
        Task<IEnumerable<UserModel>> GetAllUsers();
    }
}

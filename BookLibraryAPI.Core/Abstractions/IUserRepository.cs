using BookLibraryAPI.Domain.DTOs;
using BookLibraryAPI.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryAPI.Core.Abstractions
{
	public interface IUserRepository
	{
		Task<IEnumerable<UserDTO>> GetAllUsers();

		Task<UserDTO> GetUserByEmail(string email);

		Task<UserDTO> UpdateUserRole(string email);

		Task<UserDTO> DeleteUser(string email);
	}
}

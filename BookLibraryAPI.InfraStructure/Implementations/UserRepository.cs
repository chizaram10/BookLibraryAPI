using BookLibraryAPI.Core.Abstractions;
using BookLibraryAPI.Domain.DTOs;
using BookLibraryAPI.Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookLibraryAPI.InfraStructure.Implementations
{
	public class UserRepository : IUserRepository
	{
		private readonly UserManager<User> _userManager;

		public UserRepository(UserManager<User> userManager)
		{
			_userManager = userManager;
		}

		public async Task<IEnumerable<UserDTO>> GetAllUsers()
		{
			var result = await _userManager.Users.ToListAsync();
			return result.Select(u => new UserDTO
			{
				FirstName = u.FirstName,
				LastName = u.LastName,
				Email = u.Email,
			});
		}

		public async Task<UserDTO> GetUserByEmail(string email)
		{
			var result = await _userManager.FindByEmailAsync(email);
			return new UserDTO 
			{ 
				FirstName = result.FirstName,
				LastName = result.LastName,
				Email = result.Email,
			};
		}

		public async Task<UserDTO> UpdateUserRole(string email)
		{

			var user = await _userManager.FindByEmailAsync(email);

			try
			{
				if (user == null) return null;

				await _userManager.AddToRoleAsync(user, "Admin");
				await _userManager.RemoveFromRoleAsync(user, "Regular");

				return new UserDTO
				{
					FirstName = user.FirstName,
					LastName = user.LastName,
					Email = user.Email
				};
			}
			catch (Exception)
			{
				return null;
			}
		}

		public async Task<UserDTO> DeleteUser(string email)
		{
			var user = await _userManager.FindByEmailAsync(email);

			try
			{
				if (user == null) return null;

				await _userManager.DeleteAsync(user);

				return new UserDTO 
				{ 
					FirstName = user.FirstName,
					LastName= user.LastName, 
					Email = user.Email 
				};
			}
			catch (Exception)
			{
				return null;
			}
		}
	}
}

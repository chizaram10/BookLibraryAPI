using BookLibraryAPI.Core.Abstractions;
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

namespace BookLibraryAPI.InfraStructure.Implementations
{
	public class AuthRepository : IAuthRepository
	{
		private readonly RoleManager<IdentityRole> _roleManager;
		private readonly IConfiguration _configuration;
		private readonly UserManager<User> _userManager;

		public AuthRepository(UserManager<User> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
		{
			_roleManager = roleManager;
			_configuration = configuration;
			_userManager = userManager;
		}

		public async Task<UserDTO> RegisterUser(RegisterModel model)
		{
			var user = new User
			{
				FirstName = model.FirstName,
				LastName = model.LastName,
				Email = model.Email,
				UserName = model.Email
			};

			var result = await _userManager.CreateAsync(user, model.Password);

			try
			{
				if (result.Succeeded)
				{
					if (!await _roleManager.RoleExistsAsync("Regular"))
						await _roleManager.CreateAsync(new IdentityRole("Regular"));
					if (!await _roleManager.RoleExistsAsync("Admin"))
						await _roleManager.CreateAsync(new IdentityRole("Admin"));

					if (await _roleManager.RoleExistsAsync("Regular"))
					{
						await _userManager.AddToRoleAsync(user, "Regular");
					}
					return new UserDTO
					{
						FirstName = model.FirstName,
						LastName = model.LastName,
						Email = model.Email,
					};
				}

				else return null;
			}
			catch (Exception)
			{
				return null;
			}
		}

		public async Task<UserDTO> UserLogin(LoginModel model)
		{
			var user = await _userManager.FindByEmailAsync(model.Email);

			if (user == null) return null;

			var result = await _userManager.CheckPasswordAsync(user, model.Password);

			if (!result) return null;

			var userRoles = await _userManager.GetRolesAsync(user);

			var claims = new List<Claim>
			{
				new Claim(ClaimTypes.Name, user.UserName),
				new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
			};

			foreach (var userRole in userRoles)
			{
				claims.Add(new Claim(ClaimTypes.Role, userRole));
			}

			var authSigningKey = new SymmetricSecurityKey(
				Encoding.UTF8.GetBytes(_configuration["AuthSettings:Key"]));

			var token = new JwtSecurityToken(
				claims: claims,
				expires: DateTime.Now.AddDays(5),
				signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
				);

			string tokenAsString = new JwtSecurityTokenHandler().WriteToken(token);

			return new UserDTO
			{
				FirstName = user.UserName,
				LastName = user.UserName,
				Email = user.Email
			};
		}
	}
}

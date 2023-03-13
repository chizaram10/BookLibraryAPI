using BookLibraryAPI.Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using System.Linq;
using BookLibraryAPI.Core.Abstractions;
using BookLibraryAPI.Domain.Models;
using BookLibraryAPI.InfraStructure.Implementations;
using System;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
		private readonly IUserRepository _userRepository;
		[HttpGet]
		public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsers()
		{
			try
			{
				var result = await _userRepository.GetAllUsers();
				return result.ToList();
			}
			catch (Exception)
			{
				return StatusCode(StatusCodes.Status500InternalServerError,
					"Error retrieving data from the database");
			}
		}
		[HttpGet("{email}")]
		public async Task<ActionResult<UserDTO>> GetUser(string email)
		{
			var result = await _userRepository.GetUserByEmail(email);
			if (result == null) return NotFound();

			return result;
		}

		[HttpPut("{email}")]
		public async Task<IActionResult> PutUser_UpdateRole(string email)
		{
			var result = await _userRepository.UpdateUserRole(email);

			if (result == null) return NotFound();

			return NoContent();
		}

		[HttpDelete("{email}")]
		public async Task<ActionResult<UserDTO>> DeleteUser(string email)
		{
			var result = await _userRepository.DeleteUser(email);

			if (result == null) return NotFound();

			return result;
		}
	}
}

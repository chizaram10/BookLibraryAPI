using BookLibraryAPI.Core.Abstractions;
using BookLibraryAPI.Domain.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace BookLibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;

        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDTO>> Register([FromBody] RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authRepository.RegisterUser(model);

                if (result == null) return StatusCode(StatusCodes.Status500InternalServerError,
    "Error adding new user");

                return result;
            }

            return BadRequest();
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login([FromBody] LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _authRepository.UserLogin(model);

                if (result == null) return StatusCode(StatusCodes.Status500InternalServerError,
    "Error creating new employee record");

                return result;
            }

            return BadRequest();
        }
    }
}

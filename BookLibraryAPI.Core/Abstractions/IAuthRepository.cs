using BookLibraryAPI.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BookLibraryAPI.Core.Abstractions
{
	public interface IAuthRepository
	{
		Task<UserDTO> UserLogin(LoginModel model);

		Task<UserDTO> RegisterUser(RegisterModel model);
	}
}

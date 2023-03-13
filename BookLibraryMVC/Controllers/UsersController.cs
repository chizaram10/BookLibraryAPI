using BookLibraryMVC.Models.Models;
using BookLibraryMVC.Services.Abstractions;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookLibraryMVC.Controllers
{
	public class UsersController : Controller
	{
		private readonly IUserService _userService;
		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		public async Task<IActionResult> Index()
		{
			IEnumerable<UserModel> users = new List<UserModel>();
			var result =  await _userService.GetAllUsers();
			users = result;
			return View(users);
		}
	}
}

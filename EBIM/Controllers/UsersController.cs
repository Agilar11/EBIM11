using EBIM.DB;
using EBIM.DTO;
using EBIM.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace EBIM.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly AppDb _context;
		private readonly UserManager<User> _userManager;

		public UsersController(AppDb context, UserManager<User> userManager)
		{
			_context = context;
			_userManager = userManager;
		}

		// POST: api/Users/register
		[HttpPost("register")]
		public async Task<IActionResult> Register(UserRegisterDto userDto)
		{
			// Check if email is already registered
			if (_context.Users.Any(u => u.Email == userDto.Email))
			{
				return BadRequest("Email is already in use.");
			}

			var user = new User
			{
				UserName = userDto.UserName,
				Email = userDto.Email,
				UserEnumRole = "simpleuser",  // Default role for new users
				Status = false  // Default status is false
			};

			var result = await _userManager.CreateAsync(user, userDto.Password);
			if (!result.Succeeded)
			{
				return BadRequest(result.Errors);
			}

			return Ok("User registered successfully. Awaiting admin approval.");
		}

		// PUT: api/Users/confirm/{id}
		[HttpPut("confirm/{id}")]
		public async Task<IActionResult> ConfirmUser(int id)
		{
			var user = await _userManager.FindByIdAsync(id.ToString());
			if (user == null)
			{
				return NotFound("User not found.");
			}

			user.Status = true;  // Admin confirms user status
			await _context.SaveChangesAsync();

			return Ok("User status confirmed.");
		}
	}
}

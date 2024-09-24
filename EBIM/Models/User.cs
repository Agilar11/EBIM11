using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace EBIM.Models
{
	public class User : IdentityUser<int> // Deriving from IdentityUser with int as key
	{
		[Required]
		[StringLength(100, MinimumLength = 3, ErrorMessage = "Username must be between 3 and 100 characters.")]
		public override string UserName { get; set; }

		[Required]
		[EmailAddress(ErrorMessage = "Invalid Email Address.")]
		public override string Email { get; set; }

		public DateTime UserRegisterDate { get; set; } = DateTime.Now;

		[Required]
		public string UserEnumRole { get; set; } = "simpleuser";  // Default role

		public bool Status { get; set; } = false;  // Default status as not confirmed
	}
}

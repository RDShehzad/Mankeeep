using Microsoft.AspNetCore.Mvc;
using Mankeep.Models; // Replace with your namespace
using System.Linq;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Security.Cryptography;
using Mankeep;
using Mankeep.Models;
using System.Text;
using BCrypt.Net;


namespace YourNamespace.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AccountloginController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public AccountloginController(ApplicationDbContext context)
		{
			_context = context;
		}
		[HttpPost("Login")]
		public IActionResult Login([FromBody] LoginViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = _context.users.SingleOrDefault(u => u.Email == model.Email);
				if (user != null && VerifyPasswordHash(model.Password, user.Password))
				{
					return Ok(new { success = true });
				}
			}
			return Unauthorized(new { success = false, message = "Invalid email or password." });
		}

		private bool VerifyPasswordHash(string inputPassword, string storedHashedPassword)
		{
			// Verify password using bcrypt
			return BCrypt.Net.BCrypt.Verify(inputPassword, storedHashedPassword);
		}
	}
}

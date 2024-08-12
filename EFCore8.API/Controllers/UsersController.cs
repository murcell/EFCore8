using EFCore8.API.Data;
using EFCore8.API.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFCore8.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly MgDbContext _context;

		public UsersController(MgDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> Get()
		{
			return Ok(await _context.Users.ToListAsync());
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] UserMg user)
		{
			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();
			return Ok(user);
		}

	}
}

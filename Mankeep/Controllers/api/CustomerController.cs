using Mankeep.DTO;
using Mankeep.DTO.Mankeep.DTO;
using Mankeep.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mankeep.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomerController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IConfiguration _configuration;
		public int userId;
		public int officeid;
		public CustomerController(ApplicationDbContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
			userId = int.Parse(_configuration["AppSettings:UserId"]);
			officeid = int.Parse(_configuration["AppSettings:office_id"]);
		}

		// POST: api/Customer/addCustomer
		[HttpPost("AddCustomer")]
		public async Task<IActionResult> AddCustomer([FromBody] CustomerDTO customerdto)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var customer = new customers 
			{
				customer_name = customerdto.customer_name,
				customer_date = customerdto.customer_date,
				customer_description = customerdto.customer_description,
				customer_reference_number = customerdto.customer_reference_number,
				customer_phone = customerdto.customer_phone,
				customer_address = customerdto.customer_address,
				Balance = customerdto.Balance,
				office_id = officeid,
				created_at = DateTime.UtcNow,
				created_by = userId,




			};
			_context.customers.Add(customer);
			await _context.SaveChangesAsync();

			return Ok(); 
		}

		// GET: api/Customer/getCustomer
		[HttpGet("getCustomer")]
		public async Task<IActionResult> GetCustomer()
		{
			try
			{
				var customers = await _context.customers.ToListAsync();
				return Ok(customers);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}


		[HttpGet("getCustomer/{id}")]
		public async Task<IActionResult> GetCustomer(int id)
		{
			var customers = await _context.customers.FindAsync(id);

			if (customers == null)
			{
				return NotFound();
			}

			return Ok(customers);
		}

		// post: api/Customer/updateCustomer/{id}
		[HttpPost("updateCustomer/{id}")]
		public async Task<IActionResult> updateCustomer(int id, [FromBody] customers updatedCustomer)
		{
			if (id != updatedCustomer.customer_id)
			{
			}

			var customers = await _context.customers.FindAsync(id);
			if (customers == null)
			{
				return NotFound();
			}

			// Update Customer properties
			customers.customer_id = updatedCustomer.customer_id;
			customers.customer_name = updatedCustomer.customer_name;
			customers.customer_reference_number = updatedCustomer.customer_reference_number;
			customers.customer_phone = updatedCustomer.customer_phone;
			customers.customer_address = updatedCustomer.customer_address;
			customers.customer_description = updatedCustomer.customer_description;
			customers.customer_date = updatedCustomer.customer_date;
			customers.Balance = updatedCustomer.Balance;
			customers.updated_at = DateTime.UtcNow;
			customers.updated_by = userId;

			await _context.SaveChangesAsync();

			return Ok("Customer updated successfully.");
		}
	}
}

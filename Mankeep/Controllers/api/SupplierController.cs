using Microsoft.AspNetCore.Mvc;

using Mankeep.Models; // Assuming Supplier model is here
using System.Linq;
using System.Threading.Tasks;
using Mankeep.DTO;
using Microsoft.EntityFrameworkCore;

namespace Mankeep.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class SupplierController : Controller
	{
		private readonly ApplicationDbContext _context;
		private readonly IConfiguration _configuration;
		public int userId;
		public int officeid;
		public SupplierController(ApplicationDbContext context, IConfiguration configuration)
		{
			_context = context;
			_configuration = configuration;
			 userId = int.Parse(_configuration["AppSettings:UserId"]);
			 officeid = int.Parse(_configuration["AppSettings:office_id"]);
		}

		// POST: api/Supplier/addsupplier
		[HttpPost("Addsupplier")]
		public async Task<IActionResult> AddSupplier([FromBody] supplierDTO supplierdto)
		{

			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var supplier = new supplier // Assuming this is your entity model
			{
				supplier_name = supplierdto.supplier_name,
				supplier_date = supplierdto.supplier_date,
				supplier_description = supplierdto.supplier_description,
				supplier_reference_number = supplierdto.supplier_reference_number,
				supplier_phone = supplierdto.supplier_phone,
				supplier_address = supplierdto.supplier_address,
				Balance = supplierdto.Balance,
				office_id = officeid,
				created_at = DateTime.UtcNow,
				created_by = userId,
				



			};
			_context.suppliers.Add(supplier);
			await _context.SaveChangesAsync();

			return Ok(); // Return the added supplier as confirmation
		}

		// GET: api/Supplier/getSuppliers
		[HttpGet("getSuppliers")]
		public async Task<IActionResult> GetSuppliers()
		{
			try
			{
				var supplier = await _context.suppliers.ToListAsync();
				return Ok(supplier);
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}

		// GET: api/Supplier/getSupplier/{id}
		[HttpGet("getSupplier/{id}")]
		public async Task<IActionResult> GetSupplier(int id)
		{
			var supplier = await _context.suppliers.FindAsync(id);

			if (supplier == null)
			{
				return NotFound();
			}

			return Ok(supplier); // Return the specific supplier
		}

		// post: api/Supplier/updateSupplier/{id}
		[HttpPost("updateSupplier/{id}")]
		public async Task<IActionResult> UpdateSupplier(int id, [FromBody] supplier updatedSupplier)
		{
			if (id != updatedSupplier.supplier_id)
			{
				return BadRequest("Supplier ID mismatch.");
			}

			var supplier = await _context.suppliers.FindAsync(id);
			if (supplier == null)
			{
				return NotFound();
			}

			// Update supplier properties
			supplier.supplier_id = updatedSupplier.supplier_id;
			supplier.supplier_name = updatedSupplier.supplier_name;
			supplier.supplier_reference_number = updatedSupplier.supplier_reference_number;
			supplier.supplier_phone = updatedSupplier.supplier_phone;
			supplier.supplier_address = updatedSupplier.supplier_address;
			supplier.supplier_description = updatedSupplier.supplier_description;
			supplier.supplier_date = updatedSupplier.supplier_date;
			supplier.Balance = updatedSupplier.Balance;
			supplier.updated_at = DateTime.UtcNow;
			supplier.updated_by = userId;

			await _context.SaveChangesAsync();

			return Ok("Supplier updated successfully.");
		}
	}
}

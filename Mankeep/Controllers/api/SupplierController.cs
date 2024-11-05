using Microsoft.AspNetCore.Mvc;

using Mankeep.Models; // Assuming Supplier model is here
using System.Linq;
using System.Threading.Tasks;

namespace Mankeep.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class SupplierController : Controller
	{
		private readonly ApplicationDbContext _context;

		public SupplierController(ApplicationDbContext context)
		{
			_context = context;
		}

		// POST: api/Supplier/addsupplier
		[HttpPost("addsupplier")]
		public async Task<IActionResult> AddSupplier([FromBody] supplier supplier)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_context.suppliers.Add(supplier);
			await _context.SaveChangesAsync();

			return Ok(supplier); // Return the added supplier as confirmation
		}

		// GET: api/Supplier/getSuppliers
		[HttpGet("getSuppliers")]
		public IActionResult GetSuppliers()
		{
			var suppliers = _context.suppliers.ToList();
			return Ok(suppliers); // Return all suppliers
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

		// PUT: api/Supplier/updateSupplier/{id}
		[HttpPut("updateSupplier/{id}")]
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
			supplier.supplier_name = updatedSupplier.supplier_name;
			supplier.supplier_reference_number = updatedSupplier.supplier_reference_number;
			supplier.supplier_phone = updatedSupplier.supplier_phone;
			supplier.supplier_address = updatedSupplier.supplier_address;
			supplier.supplier_description = updatedSupplier.supplier_description;
			supplier.supplier_date = updatedSupplier.supplier_date;
			supplier.Balance = updatedSupplier.Balance;

			await _context.SaveChangesAsync();

			return Ok("Supplier updated successfully.");
		}
	}
}

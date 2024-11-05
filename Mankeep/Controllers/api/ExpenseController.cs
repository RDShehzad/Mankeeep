using Microsoft.AspNetCore.Mvc;
using Mankeep.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Mankeep.DTO;

namespace Mankeep.Controllers.api
{
	[Route("api/[controller]")]
	[ApiController]
	public class ExpenseController : ControllerBase
	{
		private readonly ApplicationDbContext _context;

		public ExpenseController(ApplicationDbContext context)
		{
			_context = context;
		}

		// Read: Fetch all categories
		[HttpGet("getCategories")]
		public async Task<IActionResult> GetCategories()
		{
			try
			{


				var categories = await _context.expense_category.ToListAsync();
				return Ok(categories);
			}
			catch (Exception ex) { 
			return BadRequest(ex.Message);
			}
		}

		// Create: Add new category
		[HttpPost("addCategory")]
		public async Task<IActionResult> AddCategory([FromBody] ExpenseCategoryDTO categorydto)
		{
			try
			{
				// Validate the incoming DTO
				if (categorydto == null || !ModelState.IsValid)
					return BadRequest("Invalid data.");

				// Create a new entity from the DTO
				var category = new expense_category // Assuming this is your entity model
				{
					expense_category_name = categorydto.expense_category_name,
					expense_category_date = categorydto.expense_category_date,
					expense_category_description = categorydto.expense_category_description,
					expense_category_reference_number = categorydto.expense_category_reference_number,
					office_id = 1,
					created_at = DateTime.UtcNow,
					created_by = 0,
					updated_at = DateTime.UtcNow,
					updated_by = null,
					deleted_at = null, // Set to null for active records
					deleted_by = null,
				};

				// Add the category to the context
				_context.expense_category.Add(category);

				// Save all changes to the database
				await _context.SaveChangesAsync();
				return Ok("Category added successfully!");
			}
			catch (Exception ex)
			{
				return BadRequest(new
				{
					message = ex.Message,
					innerException = ex.InnerException?.Message
				});
			}
		}



		// Read: Get a single category by id
		[HttpGet("getCategory/{id}")]
		public async Task<IActionResult> GetCategory(int id)
		{
			var category = await _context.expense_category.FindAsync(id);
			if (category == null)
				return NotFound("Category not found.");

			return Ok(category);
		}

		// Update: Modify an existing category
		[HttpPut("updateCategory/{id}")]
		public async Task<IActionResult> UpdateCategory(int id, [FromBody] expense_category updatedCategory)
		{
			var category = await _context.expense_category.FindAsync(id);
			if (category == null)
				return NotFound("Category not found.");

			// Update fields
			category.expense_category_name = updatedCategory.expense_category_name;
			category.expense_category_reference_number = updatedCategory.expense_category_reference_number;
			category.expense_category_date = updatedCategory.expense_category_date;
			category.expense_category_description = updatedCategory.expense_category_description;
			category.updated_at = DateTime.UtcNow;
			category.updated_by = null;  

			_context.expense_category.Update(category);
			await _context.SaveChangesAsync();
			return Ok("Category updated successfully!");
		}

		// Delete: Remove a category by id
		[HttpDelete("deleteCategory/{id}")]
		public async Task<IActionResult> DeleteCategory(int id)
		{
			var category = await _context.expense_category.FindAsync(id);
			if (category == null)
				return NotFound("Category not found.");

			_context.expense_category.Remove(category);
			await _context.SaveChangesAsync();
			return Ok("Category deleted successfully!");
		}



		[HttpPost("addexpense")]
		public async Task<IActionResult> Addexpense([FromBody] ExpenseDTO expensedto)
		{
			try
			{
				// Validate the incoming DTO
				if (expensedto == null || !ModelState.IsValid)
					return BadRequest("Invalid data.");

				// Create a new entity from the DTO
				var category = new expenses // Assuming this is your entity model
				{
					expense_category_id = expensedto.expense_category_id,
					expense_name = expensedto.expense_name,
					expense_date = expensedto.expense_date,
					expense_description = expensedto.expense_description,
					expense_reference_number = expensedto.expense_reference_number,
					office_id = 1,
					created_at = DateTime.UtcNow,
					created_by = 0,
					updated_at = DateTime.UtcNow,
					updated_by = 0,
					deleted_at = null, // Set to null for active records
					deleted_by = 0,
				};

				
				_context.expenses.Add(category);

				// Save all changes to the database
				await _context.SaveChangesAsync();
				return Ok("Category added successfully!");
			}
			catch (Exception ex)
			{
				return BadRequest(new
				{
					message = ex.Message,
					innerException = ex.InnerException?.Message
				});
			}
			
		}


		[HttpGet("GetExpenses")]
		public async Task<IActionResult> GetExpenses()
		{
			var expenses = await _context.expenses
				.Include(e => e.expense_category) // Include related ExpenseCategory
				.Select(e => new
				{
					e.expense_id,
					e.expense_category.expense_category_name,
					e.expense_name,
					e.expense_reference_number,
					e.expense_description,
					e.expense_date,
				})
				.ToListAsync();

			return Ok(expenses);
		}



	}
}

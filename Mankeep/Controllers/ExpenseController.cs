using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mankeep.Controllers
{
	public class ExpenseController : Controller
	{
		private readonly ApplicationDbContext _context;

		public ExpenseController(ApplicationDbContext context)
		{
			_context = context;
		}
		public async Task<ActionResult> Add()
		{
			// Fetch categories from the database asynchronously
			var categories = await _context.expense_category
				.Select(c => new
				{
					Id = c.expense_category_id,
					Name = c.expense_category_name
				})
				.ToListAsync();

			// Store the categories in ViewBag
			ViewBag.Categories = categories;

			// Return the view
			return View();
		}


		public ActionResult Category()
		{
			return View();
		}
			
		// GET: expense_categoryController/Details/5
		public ActionResult Details(int id)
		{
			return View();
		}

		// GET: expense_categoryController/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: expense_categoryController/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: expense_categoryController/Edit/5
		public ActionResult Edit(int id)
		{
			return View();
		}

		// POST: expense_categoryController/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}

		// GET: expense_categoryController/Delete/5
		public ActionResult Delete(int id)
		{
			return View();
		}

		// POST: expense_categoryController/Delete/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Delete(int id, IFormCollection collection)
		{
			try
			{
				return RedirectToAction(nameof(Index));
			}
			catch
			{
				return View();
			}
		}
	}
}

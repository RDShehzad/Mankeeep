using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mankeep.Controllers
{
	public class SupplierController : Controller
	{
		private readonly ApplicationDbContext _context;

		public SupplierController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<ActionResult> Add()
		{
		
			return View();
		}
	}
}

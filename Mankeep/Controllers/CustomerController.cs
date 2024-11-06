using Microsoft.AspNetCore.Mvc;

namespace Mankeep.Controllers
{
	public class CustomerController : Controller
	{
		private readonly ApplicationDbContext _context;

		public CustomerController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<ActionResult> Add()
		{

			return View();
		}
	}
}

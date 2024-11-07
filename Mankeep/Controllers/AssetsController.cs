using Microsoft.AspNetCore.Mvc;

namespace Mankeep.Controllers
{
	public class AssetsController : Controller
	{
		private readonly ApplicationDbContext _context;

		public AssetsController(ApplicationDbContext context)
		{
			_context = context;
		}

		public async Task<ActionResult> Add()
		{

			return View();
		}
	}
}

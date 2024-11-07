using Microsoft.AspNetCore.Mvc;

namespace Mankeep.Controllers
{
    public class IncomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IncomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Add()
        {

            return View();
        }
    }
}

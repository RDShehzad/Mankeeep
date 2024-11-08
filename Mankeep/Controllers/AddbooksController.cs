using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mankeep.Controllers
{
    public class AddbooksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AddbooksController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Add()
        {

            return View();
        }
    }
}

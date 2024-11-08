using Microsoft.AspNetCore.Mvc;

namespace Mankeep.Controllers
{
    public class WorkspaceController : Controller
    {
        private readonly ApplicationDbContext _context;

        public WorkspaceController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ActionResult> Index()
        {

            return View();
        }
    }
}

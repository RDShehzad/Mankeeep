using Mankeep.DTO;
using Mankeep.Models;
using Microsoft.AspNetCore.Mvc;

namespace Mankeep.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public int userId;
        public int officeid;
        public IncomeController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            userId = int.Parse(_configuration["AppSettings:UserId"]);
            officeid = int.Parse(_configuration["AppSettings:office_id"]);
        }

        [HttpGet("GetIncome")]
        public IActionResult GetIncome()
        {
            var incomeList = _context.income.ToList();
            return Ok(incomeList);
        }

        [HttpGet("getIncome/{id}")]
        public IActionResult GetIncomeById(int id)
        {
            var income = _context.income.FirstOrDefault(x => x.income_id == id);
            if (income == null)
            {
                return NotFound();
            }
            return Ok(income);
        }

        [HttpPost("AddIncome")]
        public IActionResult AddIncome([FromBody] incomeDTO incomeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var income = new income
            {
                income_amount = incomeDTO.income_amount,
                income_reference_number = incomeDTO.income_reference_number,
                income_date = incomeDTO.income_date,
                income_description = incomeDTO.income_description,
                income_reason = incomeDTO.income_reason,
                office_id = officeid,
                created_at = DateTime.UtcNow,
                created_by = userId,




            };

            _context.income.Add(income);
            _context.SaveChanges();
            return Ok();
        }

        [HttpPost("UpdateIncome/{id}")]
        public async Task<IActionResult> UpdateIncome(int id, [FromBody] income model)
        {
            var income = _context.income.FirstOrDefault(x => x.income_id == id);
            if (income == null)
            {
                return NotFound();
            }

            income.income_reference_number = model.income_reference_number;
            income.income_amount = model.income_amount;
            income.income_date = model.income_date;
            income.income_reason = model.income_reason;
            income.income_description = model.income_description;
            income.updated_at = DateTime.UtcNow;
            income.updated_by = userId;

            await _context.SaveChangesAsync();

            return Ok("Income updated successfully.");
        }
    }
}

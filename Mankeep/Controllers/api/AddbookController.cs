using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mankeep.Models;
using Mankeep.DTO;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using System;

namespace Mankeep.Controllers.api
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddbookController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;
        public int userId;
        public int officeid;

        public AddbookController(ApplicationDbContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            userId = int.Parse(_configuration["AppSettings:UserId"]);
            officeid = int.Parse(_configuration["AppSettings:office_id"]);
        }

        // POST: api/Addbook/AddBook
        [HttpPost("AddBook")]
        public async Task<IActionResult> AddBook([FromBody] AddBookDTO addBookDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var addBook = new addbooks
            {
                book_name = addBookDTO.book_name,
                book_reference_number = addBookDTO.book_reference_number,
                book_description = addBookDTO.book_description,
                book_date = addBookDTO.book_date,
                book_amount = addBookDTO.book_amount,
                office_id = officeid,
                created_at = DateTime.UtcNow,
                created_by = userId
            };

            _context.addbooks.Add(addBook);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // GET: api/Addbook/GetBooks
        [HttpGet("GetBooks")]
        public async Task<IActionResult> GetBooks()
        {
            try
            {
                var books = await _context.addbooks.ToListAsync();
                return Ok(books);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET: api/Addbook/GetBook/{id}
        [HttpGet("GetBook/{id}")]
        public async Task<IActionResult> GetBook(int id)
        {
            var book = await _context.addbooks.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST: api/Addbook/UpdateBook/{id}
        [HttpPost("UpdateBook/{id}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] addbooks updatedBook)
        {
            if (id != updatedBook.book_id)
            {
                return BadRequest("ID mismatch.");
            }

            var book = await _context.addbooks.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            // Update Book properties
            book.book_name = updatedBook.book_name;
            book.book_reference_number = updatedBook.book_reference_number;
            book.book_description = updatedBook.book_description;
            book.book_date = updatedBook.book_date;
            book.book_amount = updatedBook.book_amount;
            book.updated_at = DateTime.UtcNow;
            book.updated_by = userId;

            await _context.SaveChangesAsync();

            return Ok("Book updated successfully.");
        }

        // POST: api/Addbook/DeleteBook/{id}
        [HttpPost("DeleteBook/{id}")]
        public async Task<IActionResult> DeleteBook(int id)
        {
            var book = await _context.addbooks.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            book.deleted_at = DateTime.UtcNow;
            book.deleted_by = userId;

            await _context.SaveChangesAsync();

            return Ok("Book deleted successfully.");
        }
    }
}

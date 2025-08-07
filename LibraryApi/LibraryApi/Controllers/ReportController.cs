using LibraryApi.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReportController(AppDbContext context)
        {
            _context = context;
        }

        // 1. Belirli bir öğrencinin aldığı kitapları listeler
       
        [HttpGet("student/{studentId}")]
        public IActionResult GetBooksTakenByStudent(int studentId)
        {
            var books = _context.StudentBooks
                .Include(sb => sb.Book)
                .Where(sb => sb.StudentId == studentId)
                .Select(sb => sb.Book)
                .ToList();

            return Ok(books);
        }


        // 2. Belirli bir kütüphanedeki kitapları listeler
        [HttpGet("library/{libraryId}")]
        public IActionResult GetBooksInLibrary(int libraryId)
        {
            var books = _context.Books
                .Where(b => b.LibraryId == libraryId)
                .Select(b => new
                {
                    b.Title,
                    b.Author,
                    b.ISBN
                })
                .ToList();

            return Ok(books);
        }
    }
}

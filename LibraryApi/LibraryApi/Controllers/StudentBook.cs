using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentBookController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentBookController(AppDbContext context)
        {
            _context = context;
        }

        // 📌 1. ÖĞRENCİ KİTAP ALIR (İlişki oluşturur)
        [HttpPost]
        public IActionResult TakeBook([FromBody] StudentBook studentBook)
        {
            _context.StudentBooks.Add(studentBook);
            _context.SaveChanges();
            return Ok("Kitap alımı başarıyla kaydedildi.");
        }

        // 📌 2. TÜM ALIMLARI LİSTELE
        [HttpGet]
        public IActionResult GetAllStudentBooks()
        {
            var result = _context.StudentBooks
                .Include(sb => sb.Student)
                .Include(sb => sb.Book)
                .ToList();

            return Ok(result);
        }
    }
}

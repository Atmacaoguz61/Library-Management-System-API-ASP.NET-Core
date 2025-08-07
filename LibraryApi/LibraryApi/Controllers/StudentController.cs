// StudentController.cs

using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllStudents()
        {
            var students = _context.Students.ToList();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            return Ok(student);
        }

        // 🔐 GİRİŞ (LOGIN) - ID dön
        [HttpPost("login")]
        public IActionResult Login([FromBody] Student loginInfo)
        {
            var student = _context.Students
                .FirstOrDefault(s => s.Email == loginInfo.Email && s.Password == loginInfo.Password);

            if (student == null)
                return Unauthorized("Email veya şifre yanlış.");

            return Ok(student); // ✅ ID dönüyoruz!
        }

        [HttpPost]
        public IActionResult AddStudent([FromBody] Student student)
        {
            if (string.IsNullOrWhiteSpace(student.FullName) ||
                string.IsNullOrWhiteSpace(student.Email) ||
                string.IsNullOrWhiteSpace(student.Password))
            {
                return BadRequest("Veriler eksik.");
            }

            _context.Students.Add(student);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetStudentById), new { id = student.Id }, student);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, [FromBody] Student student)
        {
            var existing = _context.Students.Find(id);
            if (existing == null)
                return NotFound();

            existing.FullName = student.FullName;
            existing.Email = student.Email;
            existing.Password = student.Password;

            _context.SaveChanges();
            return Ok(existing);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = _context.Students.Find(id);
            if (student == null)
                return NotFound();

            _context.Students.Remove(student);
            _context.SaveChanges();
            return NoContent();
        }
    }
}

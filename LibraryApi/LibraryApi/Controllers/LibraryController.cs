using System.Linq;
using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    // 📍 API isteklerini yönetecek sınıf olduğunu belirtiyoruz
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        // 📌 EF Core aracılığıyla veritabanı işlemleri için AppDbContext nesnesi
        private readonly AppDbContext _context;

        // 🔧 Constructor: DI (Dependency Injection) ile AppDbContext'i enjekte ediyoruz
        public LibraryController(AppDbContext context)
        {
            _context = context;
        }

        // 📘 TÜM KÜTÜPHANELERİ GETİR
        // GET: api/Library
        [HttpGet]
        public IActionResult GetAllLibraries()
        {
            var libraries = _context.libraries.ToList(); // Veritabanından tüm kütüphaneler alınır
            return Ok(libraries); // 200 OK + veri döner
        }

        // 📘 BELİRLİ BİR KÜTÜPHANE GETİR
        // GET: api/Library/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLibraryById(int id)
        {
            var library = await _context.libraries.FindAsync(id); // ID'ye göre kütüphane arar

            if (library == null)
            {
                return NotFound($"ID'si {id} olan kütüphane bulunamadı.");
            }

            return Ok(library); // 200 OK + veri döner
        }

        // 📘 YENİ KÜTÜPHANE EKLE
        // POST: api/Library
        [HttpPost]
        public IActionResult AddLibrary([FromBody] Library library)
        {
            _context.libraries.Add(library);      // Yeni kütüphane EF Core'a eklenir (tracked)
            _context.SaveChanges();              // Değişiklikler veritabanına işlenir

            return CreatedAtAction(nameof(GetAllLibraries), new { id = library.Id }, library);
            // 201 Created + yeni veri döner
        }

        // 📘 KÜTÜPHANE GÜNCELLE
        // PUT: api/Library/5
        [HttpPut("{id}")]
        public IActionResult UpdateLibrary(int id, [FromBody] Library library)
        {
            var existing = _context.libraries.Find(id); // ID ile mevcut veri aranır
            if (existing == null)
                return NotFound(); // 404

            // Güncelleme işlemi
            existing.Name = library.Name;
            existing.Location = library.Location;

            _context.SaveChanges(); // Değişiklikler kaydedilir
            return Ok(existing); // 200 OK
        }

        // 📘 KÜTÜPHANE SİL
        // DELETE: api/Library/5
        [HttpDelete("{id}")]
        public IActionResult DeleteLibrary(int id)
        {
            var lib = _context.libraries.Find(id);
            if (lib == null)
                return NotFound(); // 404

            _context.libraries.Remove(lib); // Silme işlemi
            _context.SaveChanges();        // Değişiklikleri veritabanına uygula

            return NoContent(); // 204 No Content = başarı ama veri dönmüyor
        }
    }
}

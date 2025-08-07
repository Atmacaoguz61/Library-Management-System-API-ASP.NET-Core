using LibraryApi.Controllers;
using LibraryApi.Data;
using LibraryApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace LibraryApi.Controllers
{
    [Route("api/[controller]")]
   
    [ApiController]
    
    
    //ControllerBase sınıfından Controller için kalıtım aldık.
    public class BookController : ControllerBase

        //Burası sabit Constructer metodlar.
    {
        private readonly AppDbContext _context;

        public BookController(AppDbContext context)
        {
            _context = context;
        }





        //KİTAPLARI LİSTELE
        [HttpGet]
        public IActionResult GetAllBooks()
        {
            {
                var books = _context.Books.Include(b => b.Library).ToList(); // Kütüphane bilgisiyle getirir
                return Ok(books);
            }
        }




        // YENİ KİTAP EKLE
        [HttpPost]
        public IActionResult AddBook([FromBody] Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAllBooks), new { id = book.Id }, book);
        }





        // KİTAPLARI GÜNCELLEME
        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] Book book)
        {
            var existing = _context.Books.Find(id);
            if (existing == null)
                return NotFound();

            existing.Title = book.Title;
            existing.Author = book.Author;
            existing.ISBN = book.ISBN;
            existing.LibraryId = book.LibraryId;

            _context.SaveChanges();
            return Ok(existing);
        }



        // KİTAPLARI SİLME
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book == null)
                return NotFound();

            _context.Books.Remove(book);
            _context.SaveChanges();
            return NoContent(); //
        }

    }
}

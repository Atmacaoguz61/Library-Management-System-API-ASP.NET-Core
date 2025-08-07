using Microsoft.EntityFrameworkCore;
using LibraryApi.Models;

namespace LibraryApi.Data
{

    public class AppDbContext : DbContext
    {
        // Bu constructor, EF Core'un bağlanacağı ayarları alır
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }



        public DbSet <Student> Students { get; set; }
        public DbSet <Book> Books { get; set; }

        public DbSet <Library> libraries { get; set; }

        public DbSet<StudentBook> StudentBooks { get; set; }


        // Tablolar arası ilişkileri buradan yönetiriz
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Öğrenci → Kitap ilişkisi (çoktan çoka, ara tabloyla)
            modelBuilder.Entity<StudentBook>()
                .HasOne(sb => sb.Student)
                .WithMany(s => s.StudentBooks)
                .HasForeignKey(sb => sb.StudentId);

            // Kitap → Öğrenci ilişkisi
            modelBuilder.Entity<StudentBook>()
                .HasOne(sb => sb.Book)
                .WithMany(b => b.StudentBooks)
                .HasForeignKey(sb => sb.BookId);
        }
    }
}

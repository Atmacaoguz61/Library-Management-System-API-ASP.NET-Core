using System.Text.Json.Serialization;

namespace LibraryApi.Models
{
    public class Book
    {
        public int Id { get; set; } // Kitap ID'si
        public string Title { get; set; } // Kitap adı
        public string Author { get; set; } // Yazar adı
        public string ISBN { get; set; } // ISBN numarası

        public int LibraryId { get; set; } // Hangi kütüphaneye ait

        [JsonIgnore] // JSON'da gönderilmesin, sadece EF Core kullanır
        public Library? Library { get; set; }

        [JsonIgnore] // Swagger ve JSON serialization sırasında hatayı engeller
        public ICollection<StudentBook>? StudentBooks { get; set; } = new List<StudentBook>();
    }
}

using System.Text.Json.Serialization;

namespace LibraryApi.Models
{
    public class StudentBook
    {
        public int Id { get; set; } // Her kayıt için ayrı ID
        public int StudentId { get; set; } // Hangi öğrenci aldı

        [JsonIgnore]
        public Student? Student { get; set; }
       

        public int BookId { get; set; } // Hangi kitap alındı

        [JsonIgnore]
        public Book? Book { get; set; }

        public DateTime TakenDate { get; set; } = DateTime.Now; // Alındığı tarih
    }
}
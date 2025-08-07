using System.Text.Json.Serialization;

namespace LibraryApi.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }

        public string Email { get; set; } //Giriş için eklendi normalde olmaz ama bu projeye uygun.

        public string Password { get; set; } //Giriş için eklendi.

        [JsonIgnore]
        public ICollection<StudentBook>? StudentBooks { get; set; }



    }
}

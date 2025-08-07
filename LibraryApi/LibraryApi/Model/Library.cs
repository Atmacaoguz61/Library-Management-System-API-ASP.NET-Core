using System.Text.Json.Serialization;

namespace LibraryApi.Models
{
    public class Library
    {

        //Burası kütüphane isimlerinin veri tabanı KİTAPLARIN DEĞİL.

        public int Id { get; set; }

        public string Name { get; set; }

        public string Location {  get; set; }

        [JsonIgnore]
        public ICollection<Book>? Books { get; set; }

    }
}

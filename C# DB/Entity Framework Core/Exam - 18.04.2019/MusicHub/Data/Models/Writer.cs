namespace MusicHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Writer
    {
        public Writer()
        {
            Songs = new HashSet<Song>();
        }
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string Name { get; set; }

        [RegularExpression(@"^[A-Z][a-z]+ [A-Z][a-z]+$")]
        public string Pseudonym { get; set; }

        public ICollection<Song> Songs { get; set; }

        //•	Id – integer, Primary Key
        //•	Name– text with min length 3 and max length 20 (required)
        //•	Pseudonym – text, consisting of two words separated with space and each word
        //must start with one upper letter and continue with many lower-case letters(Example: "Freddie Mercury")
        //•	Songs – collection of type Song
    }
}

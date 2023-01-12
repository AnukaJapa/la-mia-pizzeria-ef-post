using PizzeriaDiAnaJaparidze.Validations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PizzeriaDiAnaJaparidze.Models
{
    public class Pizza
    {
        public int Id { get; set; }

        [Column(TypeName = "varchar(100)")]
        [StringLength(100, ErrorMessage = "Il campo Descrizione non può essere maggiore di 100 caratteri")]
        public string Description { get; set; }

        [Column(TypeName = "varchar(40)")]
        [StringLength(40, ErrorMessage = "Il campo titolo non può essere maggiore di 40 caratteri")]
        public string Title { get; set; }

        [Url(ErrorMessage ="non hai inserito il link")]
        [Image]
        public string Image { get; set; }
        

        public Pizza() { }
        public Pizza(string description, string title, string image)
        {
            Description = description;
            Title = title;
            Image = image;
        }
        
    }
}

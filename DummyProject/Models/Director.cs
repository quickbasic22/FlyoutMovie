using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace DummyProject.Models
{
    public class Director
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MaxLength(100), MinLength(3)]
        [RegularExpression(@"^[\w+\s\w+]$", ErrorMessage = "First and Last Name Required")]
        public string Name { get; set; }
        [ForeignKey("movies")]
        public Movie Movies { get; set; }
    }
}

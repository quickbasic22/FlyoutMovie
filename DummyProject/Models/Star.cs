using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DummyProject.Models
{
    public class Star
    { 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MinLength(3), MaxLength(100)]
        public string name { get; set; }
        public Movie movies { get; set; }
    }
}

using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlyoutMovie.Models
{
    public class MovieDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [DataType(DataType.MultilineText)]
        [MinLength(3), MaxLength(600, ErrorMessage = "Between 3 and 6000 Characters")]
        public string description { get; set; }
        [MinLength(3), MaxLength(60)]
        public string liked { get; set; } 
        [DataType(DataType.Date)]
        public DateTime watched { get; set; }
        [MinLength(3), MaxLength(60)]
        public string rated { get; set; }
        [DataType(DataType.Date)]
        public DateTime release_date { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal popularity { get; set; }
        public int runtime { get; set; }
        public int movieId { get; set; }

        public Movie movies { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DummyProject.Models
{
    public class WatchHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        [MinLength(3), MaxLength(100)]
        public string liked { get;  set; }
        [DataType(DataType.Date)]
        public DateTime watched { get; set; }
        public Movie movies { get; set; }
    }
}

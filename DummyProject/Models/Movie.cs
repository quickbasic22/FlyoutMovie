using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DummyProject.Models
{
    public class Movie
    {
        public Movie()
        {
            Directors = new List<Director>();
            Genres = new List<Genre>();
            Stars = new List<Star>();
            WatchHistories = new List<WatchHistory>();
            MovieDetails = new List<MovieDetail>();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [MinLength(3), MaxLength(100)]
        public string Title { get; set; }
        [Range(1900, 2100, ErrorMessage = "Between 1900 and 2100")]
        public int Year { get; set; }
        [MinLength(9), MaxLength(18)]
        public string Imdb_Id { get; set; }
        public ICollection<Director> Directors { get; set; }
        public ICollection<Genre> Genres { get; set; }
        public ICollection<Star> Stars { get; set; }
        public ICollection<WatchHistory> WatchHistories { get; set; }
        public ICollection<MovieDetail> MovieDetails { get; set; }

    }
}
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FlyoutMovie.Models
{
    public class MoviesDetails
    {
       [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Liked { get; set; }      
        public DateTime Watched { get; set; }
        public int MovieId { get; set; }
    }
}

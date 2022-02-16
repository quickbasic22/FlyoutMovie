using SQLite;
using System;

namespace FlyoutMovie.Models
{
    public class Movie
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Released { get; set; }
        public string MediaFormat { get; set; }
    }
}
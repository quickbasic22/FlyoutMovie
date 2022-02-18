using SQLite;
using System;

namespace FlyoutMovie.Models
{
    public class Movie
    {
        public static int lastId;

        [PrimaryKey, AutoIncrement]
        public int Id { get; set; } = 1;
        public string Title { get; set; } = "Movie Title";
        public DateTime Released { get; set; } = DateTime.Now;
        public string MediaFormat { get; set; } = "Blueray";

        public Movie()
        {
            Id += 1;
            lastId = Id;
        }
    }
}
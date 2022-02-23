using FlyoutMovie.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;

namespace FlyoutMovie.Data
{
    public class MovieContext : DbContext
    {
        public MovieContext()
        {
            Database.EnsureCreated();
        }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieDetail> MovieDetails { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<WatchHistory> WatchHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(@"Data Source=" + Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MovieDb.db3"));
            optionsBuilder.EnableSensitiveDataLogging(true);
        }
    }
}

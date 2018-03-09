using System;
using System.Data.Entity;

namespace MovieManager.Models
{
    public class Movie
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Director { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Rating { get; set; }
    }

    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    }
}
using System.Data.Entity;

namespace MovieMvc.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
    }

    public class MovieDbContext : DbContext
    {
        public DbSet<Movie> Movies { get; set; }
    } 
}
using System.Data.Entity;

namespace MvcSignPage.Models
{
    public class BmdDbContext : DbContext
    {
        public DbSet<User> Users { set; get; }
    }
}
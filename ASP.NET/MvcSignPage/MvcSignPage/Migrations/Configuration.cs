namespace MvcSignPage.Migrations
{
    using Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MvcSignPage.Models.BmdDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MvcSignPage.Models.BmdDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            //context.Users.AddOrUpdate(
            //    u => u.Username,
            //    new User
            //    {
            //        Username = "test",
            //        Password = "test123",
            //        Email = "test@test.com",
            //        Telephone = "18170826687"
            //    });
        }
    }
}

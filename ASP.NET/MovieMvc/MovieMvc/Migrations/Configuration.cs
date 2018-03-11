namespace MovieMvc.Migrations
{
    using Models;
    using System;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MovieMvc.Models.MovieDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MovieMvc.Models.MovieDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            context.Movies.AddOrUpdate(
                m => m.Name,
                new Movie
                {
                    Name = "The Graduate",
                    Director = "Mike Nichols",
                    Genre = "Comedy Romance",
                    ReleaseDate = DateTime.Parse("1967-12-22"),
                    Rating = "8.1"
                },
                new Movie
                {
                    Name = "Flower",
                    Director = "Max Winkler",
                    Genre = "Comedy",
                    ReleaseDate = DateTime.Parse("2018-03-16"),
                    Rating = "5.6"
                },
                new Movie
                {
                    Name = "Love, Simon",
                    Director = "Greg Berlanti",
                    Genre = "Comedy Drama Romance",
                    ReleaseDate = DateTime.Parse("2018-03-16"),
                    Rating = "7.4"
                },
                new Movie
                {
                    Name = "Nyckeln till frihet",
                    Director = " Frank Darabont",
                    Genre = "Crime Drama",
                    ReleaseDate = DateTime.Parse("1995-03-03"),
                    Rating = "9.3"
                });
        }
    }
}

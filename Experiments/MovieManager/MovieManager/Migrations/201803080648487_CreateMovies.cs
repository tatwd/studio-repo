namespace MovieManager.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMovies : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                        Director = c.String(),
                        ReleaseDate = c.DateTime(nullable: false),
                        Rating = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}

namespace BooksCatalaog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(),
                        Author = c.String(),
                        Publisher = c.String(),
                        PublishDate = c.String(),
                        IsArt = c.Boolean(nullable: false),
                        Genre = c.String(),
                        IsAvailable = c.Boolean(nullable: false),
                        User_Id = c.Guid(),
                        User_Id1 = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .ForeignKey("dbo.Users", t => t.User_Id1)
                .Index(t => t.User_Id)
                .Index(t => t.User_Id1);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Login = c.String(),
                        Password = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Books", "User_Id1", "dbo.Users");
            DropForeignKey("dbo.Books", "User_Id", "dbo.Users");
            DropIndex("dbo.Books", new[] { "User_Id1" });
            DropIndex("dbo.Books", new[] { "User_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Books");
        }
    }
}

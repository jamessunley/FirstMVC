namespace FirstMVC.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cars",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Make = c.String(),
                        Model = c.String(),
                        Price = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CarReviews",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rating = c.Int(nullable: false),
                        Body = c.String(),
                        CarsId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Cars", t => t.CarsId, cascadeDelete: true)
                .Index(t => t.CarsId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CarReviews", "CarsId", "dbo.Cars");
            DropIndex("dbo.CarReviews", new[] { "CarsId" });
            DropTable("dbo.CarReviews");
            DropTable("dbo.Cars");
        }
    }
}

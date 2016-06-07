namespace RiggenPoker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTournamentDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TournamentResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserScore = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserLadder = c.Int(nullable: false),
                        RegisteredUser_Id = c.String(maxLength: 128),
                        RotYId_Id = c.Int(),
                        TournamentId_TournamentId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RegisteredUser_Id)
                .ForeignKey("dbo.RiggenOfTheYears", t => t.RotYId_Id)
                .ForeignKey("dbo.Tournaments", t => t.TournamentId_TournamentId)
                .Index(t => t.RegisteredUser_Id)
                .Index(t => t.RotYId_Id)
                .Index(t => t.TournamentId_TournamentId);
            
            CreateTable(
                "dbo.RiggenOfTheYears",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RotYName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tournaments",
                c => new
                    {
                        TournamentId = c.Int(nullable: false, identity: true),
                        TournamentName = c.String(),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TournamentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TournamentResults", "TournamentId_TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.TournamentResults", "RotYId_Id", "dbo.RiggenOfTheYears");
            DropForeignKey("dbo.TournamentResults", "RegisteredUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.TournamentResults", new[] { "TournamentId_TournamentId" });
            DropIndex("dbo.TournamentResults", new[] { "RotYId_Id" });
            DropIndex("dbo.TournamentResults", new[] { "RegisteredUser_Id" });
            DropTable("dbo.Tournaments");
            DropTable("dbo.RiggenOfTheYears");
            DropTable("dbo.TournamentResults");
        }
    }
}

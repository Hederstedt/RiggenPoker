namespace RiggenPoker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Lagttilluserigen : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Results",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(),
                        History = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TotalScore = c.Decimal(nullable: false, precision: 18, scale: 2),
                        NewScore = c.Decimal(nullable: false, precision: 18, scale: 2),
                        UserNameId = c.Int(nullable: false),
                        UserName_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserName_Id)
                .Index(t => t.UserName_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(),
                        LastName = c.String(),
                        UserImage = c.String(),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
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
            
            CreateTable(
                "dbo.UploadImages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Image_url = c.String(),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TournamentResults", "TournamentId_TournamentId", "dbo.Tournaments");
            DropForeignKey("dbo.TournamentResults", "RotYId_Id", "dbo.RiggenOfTheYears");
            DropForeignKey("dbo.TournamentResults", "RegisteredUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Results", "UserName_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.TournamentResults", new[] { "TournamentId_TournamentId" });
            DropIndex("dbo.TournamentResults", new[] { "RotYId_Id" });
            DropIndex("dbo.TournamentResults", new[] { "RegisteredUser_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Results", new[] { "UserName_Id" });
            DropTable("dbo.UploadImages");
            DropTable("dbo.Tournaments");
            DropTable("dbo.RiggenOfTheYears");
            DropTable("dbo.TournamentResults");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Results");
        }
    }
}

namespace RiggenPoker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ny : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Files", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Files", new[] { "User_Id" });
            RenameColumn(table: "dbo.Results", name: "User_Id", newName: "UserName_Id");
            RenameIndex(table: "dbo.Results", name: "IX_User_Id", newName: "IX_UserName_Id");
            AddColumn("dbo.Results", "UserNameId", c => c.Int(nullable: false));
            DropColumn("dbo.Results", "Place");
            DropTable("dbo.Files");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                        User_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.FileId);
            
            AddColumn("dbo.Results", "Place", c => c.Int(nullable: false));
            DropColumn("dbo.Results", "UserNameId");
            RenameIndex(table: "dbo.Results", name: "IX_UserName_Id", newName: "IX_User_Id");
            RenameColumn(table: "dbo.Results", name: "UserName_Id", newName: "User_Id");
            CreateIndex("dbo.Files", "User_Id");
            AddForeignKey("dbo.Files", "User_Id", "dbo.AspNetUsers", "Id");
        }
    }
}

namespace RiggenPoker.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UploadImages",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Image_url = c.String(),
                        ImageName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.UploadImages");
        }
    }
}

namespace VidzyCodeFirst.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTagTableToDatabase : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Videos", "GenreId", "dbo.Genres");
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        TagId = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.TagId);
            
            CreateTable(
                "dbo.VideoTags",
                c => new
                    {
                        TagId = c.Int(nullable: false),
                        VideoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TagId, t.VideoId })
                .ForeignKey("dbo.Tags", t => t.TagId, cascadeDelete: true)
                .ForeignKey("dbo.Videos", t => t.VideoId, cascadeDelete: true)
                .Index(t => t.TagId)
                .Index(t => t.VideoId);
            
            AddForeignKey("dbo.Videos", "GenreId", "dbo.Genres", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Videos", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.VideoTags", "VideoId", "dbo.Videos");
            DropForeignKey("dbo.VideoTags", "TagId", "dbo.Tags");
            DropIndex("dbo.VideoTags", new[] { "VideoId" });
            DropIndex("dbo.VideoTags", new[] { "TagId" });
            DropTable("dbo.VideoTags");
            DropTable("dbo.Tags");
            AddForeignKey("dbo.Videos", "GenreId", "dbo.Genres", "Id", cascadeDelete: true);
        }
    }
}

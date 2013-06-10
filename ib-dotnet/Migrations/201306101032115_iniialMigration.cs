namespace ib_dotnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iniialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Language = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Topics",
                c => new
                    {
                        TopicId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 250),
                        Content = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TopicId)
                .ForeignKey("dbo.Users", t => t.CreatedById, cascadeDelete: true)
                .Index(t => t.CreatedById);
            
            CreateTable(
                "dbo.Replies",
                c => new
                    {
                        ReplyId = c.Int(nullable: false, identity: true),
                        Content = c.String(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        CreatedById = c.Int(nullable: false),
                        Topic_TopicId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReplyId)
                .ForeignKey("dbo.Topics", t => t.Topic_TopicId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.CreatedById)
                .Index(t => t.Topic_TopicId)
                .Index(t => t.CreatedById);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.Replies", new[] { "CreatedById" });
            DropIndex("dbo.Replies", new[] { "Topic_TopicId" });
            DropIndex("dbo.Topics", new[] { "CreatedById" });
            DropForeignKey("dbo.Replies", "CreatedById", "dbo.Users");
            DropForeignKey("dbo.Replies", "Topic_TopicId", "dbo.Topics");
            DropForeignKey("dbo.Topics", "CreatedById", "dbo.Users");
            DropTable("dbo.Replies");
            DropTable("dbo.Topics");
            DropTable("dbo.Users");
        }
    }
}

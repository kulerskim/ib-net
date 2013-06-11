namespace ib_dotnet.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class topic_reply_relationship : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Replies", name: "Topic_TopicId", newName: "TopicId");
        }
        
        public override void Down()
        {
            RenameColumn(table: "dbo.Replies", name: "TopicId", newName: "Topic_TopicId");
        }
    }
}

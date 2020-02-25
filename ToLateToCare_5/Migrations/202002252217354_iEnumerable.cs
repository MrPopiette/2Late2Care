namespace ToLateToCare_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class iEnumerable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TagModels", "TicketModel_Id", "dbo.TicketModels");
            DropIndex("dbo.TagModels", new[] { "TicketModel_Id" });
            DropColumn("dbo.TagModels", "TicketModel_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TagModels", "TicketModel_Id", c => c.Int());
            CreateIndex("dbo.TagModels", "TicketModel_Id");
            AddForeignKey("dbo.TagModels", "TicketModel_Id", "dbo.TicketModels", "Id");
        }
    }
}

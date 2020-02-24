namespace ToLateToCare_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Views : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TagModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        libelle = c.String(nullable: false),
                        TicketModel_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TicketModels", t => t.TicketModel_Id)
                .Index(t => t.TicketModel_Id);
            
            CreateTable(
                "dbo.TicketModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        titre = c.String(nullable: false, maxLength: 50),
                        description = c.String(nullable: false, maxLength: 150),
                        date = c.DateTime(nullable: false),
                        urlPhoto = c.String(),
                        auteur_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UtilisateurModels", t => t.auteur_Id, cascadeDelete: true)
                .Index(t => t.auteur_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TagModels", "TicketModel_Id", "dbo.TicketModels");
            DropForeignKey("dbo.TicketModels", "auteur_Id", "dbo.UtilisateurModels");
            DropIndex("dbo.TicketModels", new[] { "auteur_Id" });
            DropIndex("dbo.TagModels", new[] { "TicketModel_Id" });
            DropTable("dbo.TicketModels");
            DropTable("dbo.TagModels");
        }
    }
}

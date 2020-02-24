namespace ToLateToCare_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ResetTicketTag : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UtilisateurModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        pseudo = c.String(nullable: false, maxLength: 50),
                        mail = c.String(nullable: false),
                        classe_libelle = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ClasseModels", t => t.classe_libelle, cascadeDelete: true)
                .Index(t => t.classe_libelle);
            
            CreateTable(
                "dbo.ClasseModels",
                c => new
                    {
                        libelle = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.libelle);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UtilisateurModels", "classe_libelle", "dbo.ClasseModels");
            DropIndex("dbo.UtilisateurModels", new[] { "classe_libelle" });
            DropTable("dbo.ClasseModels");
            DropTable("dbo.UtilisateurModels");
        }
    }
}

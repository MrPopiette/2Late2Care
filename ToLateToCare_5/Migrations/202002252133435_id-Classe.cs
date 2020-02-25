namespace ToLateToCare_5.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class idClasse : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.UtilisateurModels", "classe_libelle", "dbo.ClasseModels");
            DropIndex("dbo.UtilisateurModels", new[] { "classe_libelle" });
            RenameColumn(table: "dbo.UtilisateurModels", name: "classe_libelle", newName: "classe_id");
            DropPrimaryKey("dbo.ClasseModels");
            AddColumn("dbo.UtilisateurModels", "password", c => c.String(nullable: false));
            AddColumn("dbo.ClasseModels", "id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UtilisateurModels", "classe_id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.ClasseModels", "id");
            CreateIndex("dbo.UtilisateurModels", "classe_id");
            AddForeignKey("dbo.UtilisateurModels", "classe_id", "dbo.ClasseModels", "id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UtilisateurModels", "classe_id", "dbo.ClasseModels");
            DropIndex("dbo.UtilisateurModels", new[] { "classe_id" });
            DropPrimaryKey("dbo.ClasseModels");
            AlterColumn("dbo.UtilisateurModels", "classe_id", c => c.String(nullable: false, maxLength: 50));
            DropColumn("dbo.ClasseModels", "id");
            DropColumn("dbo.UtilisateurModels", "password");
            AddPrimaryKey("dbo.ClasseModels", "libelle");
            RenameColumn(table: "dbo.UtilisateurModels", name: "classe_id", newName: "classe_libelle");
            CreateIndex("dbo.UtilisateurModels", "classe_libelle");
            AddForeignKey("dbo.UtilisateurModels", "classe_libelle", "dbo.ClasseModels", "libelle", cascadeDelete: true);
        }
    }
}

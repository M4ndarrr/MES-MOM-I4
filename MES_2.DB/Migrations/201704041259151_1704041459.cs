namespace MES_2.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1704041459 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.STA_StateList", "ENT_Entity_ID_ENT", "dbo.ENT_Entity");
            DropForeignKey("dbo.TRA_TranslationState", "ENT_Entity_ID_ENT", "dbo.ENT_Entity");
            DropIndex("dbo.STA_StateList", new[] { "ENT_Entity_ID_ENT" });
            DropIndex("dbo.TRA_TranslationState", new[] { "ENT_Entity_ID_ENT" });
            RenameColumn(table: "dbo.STA_StateList", name: "ENT_Entity_ID_ENT", newName: "ID_ENT");
            RenameColumn(table: "dbo.TRA_TranslationState", name: "ENT_Entity_ID_ENT", newName: "ID_ENT");
            AlterColumn("dbo.STA_StateList", "ID_ENT", c => c.Int(nullable: false));
            AlterColumn("dbo.TRA_TranslationState", "ID_ENT", c => c.Int(nullable: false));
            CreateIndex("dbo.STA_StateList", "ID_ENT");
            CreateIndex("dbo.TRA_TranslationState", "ID_ENT");
            AddForeignKey("dbo.STA_StateList", "ID_ENT", "dbo.ENT_Entity", "ID_ENT", cascadeDelete: true);
            AddForeignKey("dbo.TRA_TranslationState", "ID_ENT", "dbo.ENT_Entity", "ID_ENT", cascadeDelete: true);
            DropColumn("dbo.STA_StateList", "NAME_ENT");
            DropColumn("dbo.TRA_TranslationState", "NAME_ENT");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TRA_TranslationState", "NAME_ENT", c => c.String());
            AddColumn("dbo.STA_StateList", "NAME_ENT", c => c.String());
            DropForeignKey("dbo.TRA_TranslationState", "ID_ENT", "dbo.ENT_Entity");
            DropForeignKey("dbo.STA_StateList", "ID_ENT", "dbo.ENT_Entity");
            DropIndex("dbo.TRA_TranslationState", new[] { "ID_ENT" });
            DropIndex("dbo.STA_StateList", new[] { "ID_ENT" });
            AlterColumn("dbo.TRA_TranslationState", "ID_ENT", c => c.Int());
            AlterColumn("dbo.STA_StateList", "ID_ENT", c => c.Int());
            RenameColumn(table: "dbo.TRA_TranslationState", name: "ID_ENT", newName: "ENT_Entity_ID_ENT");
            RenameColumn(table: "dbo.STA_StateList", name: "ID_ENT", newName: "ENT_Entity_ID_ENT");
            CreateIndex("dbo.TRA_TranslationState", "ENT_Entity_ID_ENT");
            CreateIndex("dbo.STA_StateList", "ENT_Entity_ID_ENT");
            AddForeignKey("dbo.TRA_TranslationState", "ENT_Entity_ID_ENT", "dbo.ENT_Entity", "ID_ENT");
            AddForeignKey("dbo.STA_StateList", "ENT_Entity_ID_ENT", "dbo.ENT_Entity", "ID_ENT");
        }
    }
}

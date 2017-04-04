namespace MES_2.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _17040401117 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TRA_TranslationState", "STA_StateList_ID_STA", "dbo.STA_StateList");
            DropForeignKey("dbo.TRA_TranslationState", "STA_StateList_ID_STA1", "dbo.STA_StateList");
            DropIndex("dbo.TRA_TranslationState", new[] { "STATE_FROM_ID_STA" });
            DropIndex("dbo.TRA_TranslationState", new[] { "STATE_TO_ID_STA" });
            DropIndex("dbo.TRA_TranslationState", new[] { "STA_StateList_ID_STA" });
            DropIndex("dbo.TRA_TranslationState", new[] { "STA_StateList_ID_STA1" });
            RenameColumn(table: "dbo.TRA_TranslationState", name: "STATE_FROM_ID_STA", newName: "ID_STA_PICA_FROM");
            RenameColumn(table: "dbo.TRA_TranslationState", name: "STATE_TO_ID_STA", newName: "ID_STA_PICA_TO");
            AlterColumn("dbo.TRA_TranslationState", "ID_STA_PICA_FROM", c => c.Int(nullable: false));
            AlterColumn("dbo.TRA_TranslationState", "ID_STA_PICA_TO", c => c.Int(nullable: false));
            CreateIndex("dbo.TRA_TranslationState", "ID_STA_PICA_FROM");
            CreateIndex("dbo.TRA_TranslationState", "ID_STA_PICA_TO");
            DropColumn("dbo.TRA_TranslationState", "STA_StateList_ID_STA");
            DropColumn("dbo.TRA_TranslationState", "STA_StateList_ID_STA1");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TRA_TranslationState", "STA_StateList_ID_STA1", c => c.Int());
            AddColumn("dbo.TRA_TranslationState", "STA_StateList_ID_STA", c => c.Int());
            DropIndex("dbo.TRA_TranslationState", new[] { "ID_STA_PICA_TO" });
            DropIndex("dbo.TRA_TranslationState", new[] { "ID_STA_PICA_FROM" });
            AlterColumn("dbo.TRA_TranslationState", "ID_STA_PICA_TO", c => c.Int());
            AlterColumn("dbo.TRA_TranslationState", "ID_STA_PICA_FROM", c => c.Int());
            RenameColumn(table: "dbo.TRA_TranslationState", name: "ID_STA_PICA_TO", newName: "STATE_TO_ID_STA");
            RenameColumn(table: "dbo.TRA_TranslationState", name: "ID_STA_PICA_FROM", newName: "STATE_FROM_ID_STA");
            CreateIndex("dbo.TRA_TranslationState", "STA_StateList_ID_STA1");
            CreateIndex("dbo.TRA_TranslationState", "STA_StateList_ID_STA");
            CreateIndex("dbo.TRA_TranslationState", "STATE_TO_ID_STA");
            CreateIndex("dbo.TRA_TranslationState", "STATE_FROM_ID_STA");
            AddForeignKey("dbo.TRA_TranslationState", "STA_StateList_ID_STA1", "dbo.STA_StateList", "ID_STA");
            AddForeignKey("dbo.TRA_TranslationState", "STA_StateList_ID_STA", "dbo.STA_StateList", "ID_STA");
        }
    }
}

namespace MES_2.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _170404 : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.RES_ResultTable", "ID_COM");
            AddForeignKey("dbo.RES_ResultTable", "ID_COM", "dbo.COM_ComObject", "ID_COM", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RES_ResultTable", "ID_COM", "dbo.COM_ComObject");
            DropIndex("dbo.RES_ResultTable", new[] { "ID_COM" });
        }
    }
}

namespace MES_2.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _978979 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.COM_ComObject", "ID_PLC", "dbo.PLC_PLCConnector");
            DropIndex("dbo.COM_ComObject", new[] { "ID_PLC" });
            DropPrimaryKey("dbo.COM_ComObject");
            DropPrimaryKey("dbo.PLC_PLCConnector");
            AlterColumn("dbo.COM_ComObject", "ID_COM", c => c.Guid(nullable: false));
            AlterColumn("dbo.COM_ComObject", "ID_PLC", c => c.Guid(nullable: false));
            AlterColumn("dbo.PLC_PLCConnector", "ID_PLC", c => c.Guid(nullable: false));
            AlterColumn("dbo.RES_ResultTable", "ID_COM", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.COM_ComObject", "ID_COM");
            AddPrimaryKey("dbo.PLC_PLCConnector", "ID_PLC");
            CreateIndex("dbo.COM_ComObject", "ID_PLC");
            AddForeignKey("dbo.COM_ComObject", "ID_PLC", "dbo.PLC_PLCConnector", "ID_PLC", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.COM_ComObject", "ID_PLC", "dbo.PLC_PLCConnector");
            DropIndex("dbo.COM_ComObject", new[] { "ID_PLC" });
            DropPrimaryKey("dbo.PLC_PLCConnector");
            DropPrimaryKey("dbo.COM_ComObject");
            AlterColumn("dbo.RES_ResultTable", "ID_COM", c => c.String());
            AlterColumn("dbo.PLC_PLCConnector", "ID_PLC", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.COM_ComObject", "ID_PLC", c => c.String(maxLength: 128));
            AlterColumn("dbo.COM_ComObject", "ID_COM", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.PLC_PLCConnector", "ID_PLC");
            AddPrimaryKey("dbo.COM_ComObject", "ID_COM");
            CreateIndex("dbo.COM_ComObject", "ID_PLC");
            AddForeignKey("dbo.COM_ComObject", "ID_PLC", "dbo.PLC_PLCConnector", "ID_PLC");
        }
    }
}

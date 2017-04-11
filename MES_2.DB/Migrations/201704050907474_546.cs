namespace MES_2.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _546 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.COM_ComObject",
                c => new
                    {
                        ID_COM = c.String(nullable: false, maxLength: 128),
                        ID_PLC = c.String(maxLength: 128),
                        Status = c.Int(nullable: false),
                        ReadWrite = c.Int(nullable: false),
                        AreaMemory = c.Int(nullable: false),
                        StartOffSet = c.Int(nullable: false),
                        WorldLen = c.Int(nullable: false),
                        DBnumber = c.Int(nullable: false),
                        Period = c.Int(nullable: false),
                        P_Created = c.String(),
                        P_Modified = c.String(),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_COM)
                .ForeignKey("dbo.PLC_PLCConnector", t => t.ID_PLC)
                .Index(t => t.ID_PLC);
            
            CreateTable(
                "dbo.PLC_PLCConnector",
                c => new
                    {
                        ID_PLC = c.String(nullable: false, maxLength: 128),
                        Status = c.Int(nullable: false),
                        IP = c.String(),
                        Port = c.String(),
                        Slot = c.Int(nullable: false),
                        Rack = c.Int(nullable: false),
                        P_Created = c.String(),
                        P_Modified = c.String(),
                        TimeCreated = c.DateTime(nullable: false),
                        TimeModified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID_PLC);
            
            CreateTable(
                "dbo.RES_ResultTable",
                c => new
                    {
                        ID_RES = c.Int(nullable: false, identity: true),
                        PLCStamp = c.DateTime(nullable: false),
                        ID_COM = c.String(),
                        ResultData = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_RES);
            
            DropTable("dbo.ComObjectTables");
            DropTable("dbo.PLCTables");
            DropTable("dbo.ResultTables");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ResultTables",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        PLCStamp = c.DateTime(nullable: false),
                        IDComObject = c.String(),
                        ResultData = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.PLCTables",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        Status = c.Int(nullable: false),
                        IP = c.String(),
                        Port = c.String(),
                        Slot = c.Int(nullable: false),
                        Rack = c.Int(nullable: false),
                        P_Created = c.String(),
                        P_Modified = c.String(),
                        TimeCreated = c.DateTime(),
                        TimeModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ComObjectTables",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        IDPLC = c.String(),
                        Status = c.Int(nullable: false),
                        ReadWrite = c.Int(nullable: false),
                        AreaMemory = c.Int(nullable: false),
                        StartOffSet = c.Int(nullable: false),
                        WorldLen = c.Int(nullable: false),
                        DBnumber = c.Int(nullable: false),
                        Period = c.Int(nullable: false),
                        P_Created = c.String(),
                        P_Modified = c.String(),
                        TimeCreated = c.DateTime(),
                        TimeModified = c.DateTime(),
                    })
                .PrimaryKey(t => t.ID);
            
            DropForeignKey("dbo.COM_ComObject", "ID_PLC", "dbo.PLC_PLCConnector");
            DropIndex("dbo.COM_ComObject", new[] { "ID_PLC" });
            DropTable("dbo.RES_ResultTable");
            DropTable("dbo.PLC_PLCConnector");
            DropTable("dbo.COM_ComObject");
        }
    }
}

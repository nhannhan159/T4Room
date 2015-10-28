namespace RoomM.Repositories.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RoomCalendars",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Start = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        RoomId = c.Long(),
                        StaffId = c.Long(),
                        RoomCalendarStatusId = c.Long(),
                        IsWatched = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.RoomCalendarStatuses", t => t.RoomCalendarStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Staffs", t => t.StaffId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.StaffId)
                .Index(t => t.RoomCalendarStatusId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 120),
                        DateCreate = c.DateTime(nullable: false),
                        RoomTypeId = c.Long(),
                        IsUsing = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeId, cascadeDelete: true)
                .Index(t => t.RoomTypeId);
            
            CreateTable(
                "dbo.RoomAssetHistorys",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        AssetHistoryTypeId = c.Long(),
                        Date = c.DateTime(nullable: false),
                        AssetId = c.Long(),
                        RoomId = c.Long(),
                        Room2 = c.String(),
                        Amount = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Assets", t => t.AssetId, cascadeDelete: true)
                .ForeignKey("dbo.HistoryTypes", t => t.AssetHistoryTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.AssetHistoryTypeId)
                .Index(t => t.AssetId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.Assets",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        IsUsing = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoomAssets",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        RoomId = c.Long(),
                        AssetId = c.Long(),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Assets", t => t.AssetId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.AssetId);
            
            CreateTable(
                "dbo.HistoryTypes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoomCalendarStatuses",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Staffs",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Sex = c.Boolean(nullable: false),
                        Phone = c.String(maxLength: 15),
                        StaffTypeId = c.Long(),
                        UserName = c.String(nullable: false, maxLength: 50),
                        PasswordStored = c.String(nullable: false, maxLength: 30),
                        IsWorking = c.Boolean(nullable: false),
                        Description = c.String(),
                        LastLogin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.StaffTypes", t => t.StaffTypeId, cascadeDelete: true)
                .Index(t => t.StaffTypeId);
            
            CreateTable(
                "dbo.StaffTypes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RoomCalendars", "StaffId", "dbo.Staffs");
            DropForeignKey("dbo.Staffs", "StaffTypeId", "dbo.StaffTypes");
            DropForeignKey("dbo.RoomCalendars", "RoomCalendarStatusId", "dbo.RoomCalendarStatuses");
            DropForeignKey("dbo.RoomCalendars", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.RoomAssetHistorys", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomAssetHistorys", "AssetHistoryTypeId", "dbo.HistoryTypes");
            DropForeignKey("dbo.RoomAssetHistorys", "AssetId", "dbo.Assets");
            DropForeignKey("dbo.RoomAssets", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.RoomAssets", "AssetId", "dbo.Assets");
            DropIndex("dbo.Staffs", new[] { "StaffTypeId" });
            DropIndex("dbo.RoomAssets", new[] { "AssetId" });
            DropIndex("dbo.RoomAssets", new[] { "RoomId" });
            DropIndex("dbo.RoomAssetHistorys", new[] { "RoomId" });
            DropIndex("dbo.RoomAssetHistorys", new[] { "AssetId" });
            DropIndex("dbo.RoomAssetHistorys", new[] { "AssetHistoryTypeId" });
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            DropIndex("dbo.RoomCalendars", new[] { "RoomCalendarStatusId" });
            DropIndex("dbo.RoomCalendars", new[] { "StaffId" });
            DropIndex("dbo.RoomCalendars", new[] { "RoomId" });
            DropTable("dbo.StaffTypes");
            DropTable("dbo.Staffs");
            DropTable("dbo.RoomCalendarStatuses");
            DropTable("dbo.RoomTypes");
            DropTable("dbo.HistoryTypes");
            DropTable("dbo.RoomAssets");
            DropTable("dbo.Assets");
            DropTable("dbo.RoomAssetHistorys");
            DropTable("dbo.Rooms");
            DropTable("dbo.RoomCalendars");
        }
    }
}

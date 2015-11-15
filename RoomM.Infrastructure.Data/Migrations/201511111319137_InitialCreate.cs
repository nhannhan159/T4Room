namespace RoomM.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
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
                "dbo.AssetDetails",
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
                "dbo.AssetHistorys",
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
                .ForeignKey("dbo.AssetHistoryTypes", t => t.AssetHistoryTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.AssetHistoryTypeId)
                .Index(t => t.AssetId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.AssetHistoryTypes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.RoomRegs",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Start = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        RoomId = c.Long(),
                        UserId = c.Long(),
                        RoomRegTypeId = c.Long(),
                        IsWatched = c.Boolean(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.RoomRegTypes", t => t.RoomRegTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.UserId)
                .Index(t => t.RoomRegTypeId);
            
            CreateTable(
                "dbo.RoomRegTypes",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Sex = c.Boolean(nullable: false),
                        Phone = c.String(maxLength: 15),
                        UserRoleId = c.Long(),
                        UserName = c.String(nullable: false, maxLength: 50),
                        PasswordStored = c.String(nullable: false, maxLength: 30),
                        IsWorking = c.Boolean(nullable: false),
                        Description = c.String(),
                        LastLogin = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.UserRoles", t => t.UserRoleId, cascadeDelete: true)
                .Index(t => t.UserRoleId);
            
            CreateTable(
                "dbo.UserRoles",
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssetDetails", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.RoomRegs", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "UserRoleId", "dbo.UserRoles");
            DropForeignKey("dbo.RoomRegs", "RoomRegTypeId", "dbo.RoomRegTypes");
            DropForeignKey("dbo.RoomRegs", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.AssetHistorys", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.AssetHistorys", "AssetHistoryTypeId", "dbo.AssetHistoryTypes");
            DropForeignKey("dbo.AssetHistorys", "AssetId", "dbo.Assets");
            DropForeignKey("dbo.AssetDetails", "AssetId", "dbo.Assets");
            DropIndex("dbo.Users", new[] { "UserRoleId" });
            DropIndex("dbo.RoomRegs", new[] { "RoomRegTypeId" });
            DropIndex("dbo.RoomRegs", new[] { "UserId" });
            DropIndex("dbo.RoomRegs", new[] { "RoomId" });
            DropIndex("dbo.AssetHistorys", new[] { "RoomId" });
            DropIndex("dbo.AssetHistorys", new[] { "AssetId" });
            DropIndex("dbo.AssetHistorys", new[] { "AssetHistoryTypeId" });
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            DropIndex("dbo.AssetDetails", new[] { "AssetId" });
            DropIndex("dbo.AssetDetails", new[] { "RoomId" });
            DropTable("dbo.RoomTypes");
            DropTable("dbo.UserRoles");
            DropTable("dbo.Users");
            DropTable("dbo.RoomRegTypes");
            DropTable("dbo.RoomRegs");
            DropTable("dbo.AssetHistoryTypes");
            DropTable("dbo.AssetHistorys");
            DropTable("dbo.Rooms");
            DropTable("dbo.AssetDetails");
            DropTable("dbo.Assets");
        }
    }
}

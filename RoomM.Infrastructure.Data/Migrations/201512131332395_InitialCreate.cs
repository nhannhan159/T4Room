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
                        Id = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        IsUsing = c.Boolean(nullable: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.AssetDetails",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        RoomId = c.String(maxLength: 100, storeType: "nvarchar"),
                        AssetId = c.String(maxLength: 100, storeType: "nvarchar"),
                        Amount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assets", t => t.AssetId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.AssetId);
            
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Name = c.String(nullable: false, maxLength: 120, storeType: "nvarchar"),
                        DateCreate = c.DateTime(nullable: false, precision: 0),
                        RoomTypeId = c.String(maxLength: 100, storeType: "nvarchar"),
                        IsUsing = c.Boolean(nullable: false),
                        Description = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.RoomTypeId);
            
            CreateTable(
                "dbo.AssetHistorys",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        AssetHistoryType = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false, precision: 0),
                        AssetId = c.String(maxLength: 100, storeType: "nvarchar"),
                        RoomId = c.String(maxLength: 100, storeType: "nvarchar"),
                        Room2 = c.String(unicode: false),
                        Amount = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Assets", t => t.AssetId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .Index(t => t.AssetId)
                .Index(t => t.RoomId);
            
            CreateTable(
                "dbo.RoomRegs",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Date = c.DateTime(nullable: false, precision: 0),
                        Start = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        RoomId = c.String(maxLength: 100, storeType: "nvarchar"),
                        UserId = c.String(maxLength: 100, storeType: "nvarchar"),
                        RoomRegType = c.Int(nullable: false),
                        IsWatched = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Rooms", t => t.RoomId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoomId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        FullName = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        UserName = c.String(nullable: false, maxLength: 50, storeType: "nvarchar"),
                        PasswordHash = c.String(nullable: false, unicode: false),
                        IsWorking = c.Boolean(nullable: false),
                        Sex = c.Boolean(),
                        Phone = c.String(maxLength: 15, storeType: "nvarchar"),
                        LastLogin = c.DateTime(precision: 0),
                        Description = c.String(unicode: false),
                        AccessFailedCount = c.Int(),
                        LockoutEnabled = c.Boolean(),
                        LockoutEndDateUtc = c.DateTime(precision: 0),
                        TwoFactorEnabled = c.Boolean(),
                        SecurityStamp = c.String(unicode: false),
                        RoleId = c.String(maxLength: 100, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.FullName, unique: true)
                .Index(t => t.UserName, unique: true)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Name = c.String(maxLength: 50, storeType: "nvarchar"),
                        FullName = c.String(maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true)
                .Index(t => t.FullName, unique: true);
            
            CreateTable(
                "dbo.UserClaims",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        UserId = c.String(maxLength: 100, storeType: "nvarchar"),
                        ClaimType = c.String(unicode: false),
                        ClaimValue = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserLogins",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        UserId = c.String(maxLength: 100, storeType: "nvarchar"),
                        LoginProvider = c.String(unicode: false),
                        ProviderKey = c.String(unicode: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 100, storeType: "nvarchar"),
                        Name = c.String(maxLength: 50, storeType: "nvarchar"),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssetDetails", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.RoomRegs", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserLogins", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserClaims", "UserId", "dbo.Users");
            DropForeignKey("dbo.Users", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.RoomRegs", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.AssetHistorys", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.AssetHistorys", "AssetId", "dbo.Assets");
            DropForeignKey("dbo.AssetDetails", "AssetId", "dbo.Assets");
            DropIndex("dbo.RoomTypes", new[] { "Name" });
            DropIndex("dbo.UserLogins", new[] { "UserId" });
            DropIndex("dbo.UserClaims", new[] { "UserId" });
            DropIndex("dbo.Roles", new[] { "FullName" });
            DropIndex("dbo.Roles", new[] { "Name" });
            DropIndex("dbo.Users", new[] { "RoleId" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.Users", new[] { "FullName" });
            DropIndex("dbo.RoomRegs", new[] { "UserId" });
            DropIndex("dbo.RoomRegs", new[] { "RoomId" });
            DropIndex("dbo.AssetHistorys", new[] { "RoomId" });
            DropIndex("dbo.AssetHistorys", new[] { "AssetId" });
            DropIndex("dbo.Rooms", new[] { "RoomTypeId" });
            DropIndex("dbo.Rooms", new[] { "Name" });
            DropIndex("dbo.AssetDetails", new[] { "AssetId" });
            DropIndex("dbo.AssetDetails", new[] { "RoomId" });
            DropIndex("dbo.Assets", new[] { "Name" });
            DropTable("dbo.RoomTypes");
            DropTable("dbo.UserLogins");
            DropTable("dbo.UserClaims");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.RoomRegs");
            DropTable("dbo.AssetHistorys");
            DropTable("dbo.Rooms");
            DropTable("dbo.AssetDetails");
            DropTable("dbo.Assets");
        }
    }
}

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
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        IsUsing = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.AssetDetails",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        RoomId = c.Long(),
                        AssetId = c.Long(),
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
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 120),
                        DateCreate = c.DateTime(nullable: false),
                        RoomTypeId = c.Long(),
                        IsUsing = c.Boolean(nullable: false),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.RoomTypes", t => t.RoomTypeId, cascadeDelete: true)
                .Index(t => t.Name, unique: true)
                .Index(t => t.RoomTypeId);
            
            CreateTable(
                "dbo.AssetHistorys",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        AssetHistoryTypeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        AssetId = c.Long(),
                        RoomId = c.Long(),
                        Room2 = c.String(),
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
                        Id = c.Long(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        Start = c.Int(nullable: false),
                        Length = c.Int(nullable: false),
                        RoomId = c.Long(),
                        UserId = c.Long(),
                        RoomRegTypeId = c.Int(nullable: false),
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
                        Id = c.Long(nullable: false, identity: true),
                        FullName = c.String(nullable: false, maxLength: 50),
                        UserName = c.String(nullable: false, maxLength: 50),
                        PasswordHash = c.String(nullable: false),
                        IsWorking = c.Boolean(nullable: false),
                        Sex = c.Boolean(),
                        Phone = c.String(maxLength: 15),
                        Description = c.String(),
                        AccessFailedCount = c.Int(),
                        LockoutEnabled = c.Boolean(),
                        LockoutEndDateUtc = c.DateTime(),
                        TwoFactorEnabled = c.Boolean(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.FullName, unique: true)
                .Index(t => t.UserName, unique: true);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.RoomTypes",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        Name = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true);
            
            CreateTable(
                "dbo.UsersInRoles",
                c => new
                    {
                        UserId = c.Long(nullable: false),
                        RoleId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssetDetails", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.Rooms", "RoomTypeId", "dbo.RoomTypes");
            DropForeignKey("dbo.RoomRegs", "UserId", "dbo.Users");
            DropForeignKey("dbo.UsersInRoles", "RoleId", "dbo.Roles");
            DropForeignKey("dbo.UsersInRoles", "UserId", "dbo.Users");
            DropForeignKey("dbo.RoomRegs", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.AssetHistorys", "RoomId", "dbo.Rooms");
            DropForeignKey("dbo.AssetHistorys", "AssetId", "dbo.Assets");
            DropForeignKey("dbo.AssetDetails", "AssetId", "dbo.Assets");
            DropIndex("dbo.UsersInRoles", new[] { "RoleId" });
            DropIndex("dbo.UsersInRoles", new[] { "UserId" });
            DropIndex("dbo.RoomTypes", new[] { "Name" });
            DropIndex("dbo.Roles", new[] { "Name" });
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
            DropTable("dbo.UsersInRoles");
            DropTable("dbo.RoomTypes");
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

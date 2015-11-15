namespace RoomM.Infrastructure.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUniqueConstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Assets", "Name", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.AssetHistoryTypes", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.RoomRegTypes", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.UserRoles", "Name", c => c.String(maxLength: 50));
            AlterColumn("dbo.RoomTypes", "Name", c => c.String(maxLength: 50));
            CreateIndex("dbo.Assets", "Name", unique: true);
            CreateIndex("dbo.Rooms", "Name", unique: true);
            CreateIndex("dbo.AssetHistoryTypes", "Name", unique: true);
            CreateIndex("dbo.RoomRegTypes", "Name", unique: true);
            CreateIndex("dbo.Users", "Name", unique: true);
            CreateIndex("dbo.Users", "UserName", unique: true);
            CreateIndex("dbo.UserRoles", "Name", unique: true);
            CreateIndex("dbo.RoomTypes", "Name", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.RoomTypes", new[] { "Name" });
            DropIndex("dbo.UserRoles", new[] { "Name" });
            DropIndex("dbo.Users", new[] { "UserName" });
            DropIndex("dbo.Users", new[] { "Name" });
            DropIndex("dbo.RoomRegTypes", new[] { "Name" });
            DropIndex("dbo.AssetHistoryTypes", new[] { "Name" });
            DropIndex("dbo.Rooms", new[] { "Name" });
            DropIndex("dbo.Assets", new[] { "Name" });
            AlterColumn("dbo.RoomTypes", "Name", c => c.String());
            AlterColumn("dbo.UserRoles", "Name", c => c.String());
            AlterColumn("dbo.RoomRegTypes", "Name", c => c.String());
            AlterColumn("dbo.AssetHistoryTypes", "Name", c => c.String());
            AlterColumn("dbo.Assets", "Name", c => c.String(nullable: false));
        }
    }
}

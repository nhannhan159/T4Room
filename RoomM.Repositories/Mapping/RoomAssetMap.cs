using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Repositories.Mapping
{
    public class RoomAssetMap : EntityTypeConfiguration<RoomAsset>
    {
        public RoomAssetMap() 
        {
            // key
            HasKey(t => t.ID);

            // property
            Property(t => t.RoomId).IsOptional();
            Property(t => t.AssetId).IsOptional();
            Property(t => t.Amount).IsRequired();

            // table
            ToTable("RoomAssets");

            // replationship
            HasOptional(t => t.Room).WithMany(c => c.RoomAssets)
                .HasForeignKey(t => t.RoomId).WillCascadeOnDelete(true);
            HasOptional(t => t.Asset).WithMany(c => c.RoomAssets)
                .HasForeignKey(t => t.AssetId).WillCascadeOnDelete(true);
            

        }
    }
}

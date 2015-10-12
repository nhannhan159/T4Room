using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomM.Models.Mapping
{
    public class RoomAssetHistoryMap : EntityTypeConfiguration<RoomAssetHistory>
    {
        public RoomAssetHistoryMap()
        { 
            // key
            HasKey(t => t.ID);

            // properties
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Date);
            Property(t => t.AssetHistoryTypeId).IsOptional();
            Property(t => t.AssetId).IsOptional();
            Property(t => t.RoomId).IsOptional();
            Property(t => t.Room2).IsOptional();
            Property(t => t.Amount).IsOptional();

            // table
            ToTable("RoomAssetHistorys");

            // relationship
            HasOptional(t => t.HistoryType).WithMany(c => c.AssetHistories)
                .HasForeignKey(t => t.AssetHistoryTypeId).WillCascadeOnDelete(true);
            HasOptional(t => t.Asset).WithMany(c => c.AssetHistories)
                .HasForeignKey(t => t.AssetId).WillCascadeOnDelete(true);
            HasOptional(t => t.Room).WithMany(c => c.AssetHistories)
                .HasForeignKey(t => t.RoomId).WillCascadeOnDelete(true);
        }

    }
}

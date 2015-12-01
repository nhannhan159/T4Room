using RoomM.Domain.AssetModule.Aggregates;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace RoomM.Infrastructure.Data.UnitOfWork.Mapping
{
    public class AssetHistoryConfiguration : EntityTypeConfiguration<AssetHistory>
    {
        public AssetHistoryConfiguration()
        {
            // key
            this.HasKey(t => t.Id);

            // properties
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Date);
            this.Property(t => t.AssetHistoryTypeId).IsRequired();
            this.Property(t => t.AssetId).IsOptional();
            this.Property(t => t.RoomId).IsOptional();
            this.Property(t => t.Room2).IsOptional();
            this.Property(t => t.Amount).IsOptional();

            // table
            this.ToTable("AssetHistorys");

            // relationship
            this.HasOptional(t => t.Asset)
                .WithMany(c => c.AssetHistories)
                .HasForeignKey(t => t.AssetId)
                .WillCascadeOnDelete(true);
            this.HasOptional(t => t.Room)
                .WithMany(c => c.AssetHistories)
                .HasForeignKey(t => t.RoomId)
                .WillCascadeOnDelete(true);
        }
    }
}
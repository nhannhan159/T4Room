using RoomM.Domain.AssetModule.Aggregates;
using System.Data.Entity.ModelConfiguration;

namespace RoomM.Infrastructure.Data.UnitOfWork.Mapping
{
    public class AssetDetailConfiguration : EntityTypeConfiguration<AssetDetail>
    {
        public AssetDetailConfiguration()
        {
            // key
            this.HasKey(t => t.Id);

            // property
            this.Property(t => t.RoomId).IsOptional();
            this.Property(t => t.AssetId).IsOptional();
            this.Property(t => t.Amount).IsRequired();

            // table
            this.ToTable("AssetDetails");

            // replationship
            this.HasOptional(t => t.Room)
                .WithMany(c => c.AssetDetails)
                .HasForeignKey(t => t.RoomId)
                .WillCascadeOnDelete(true);
            this.HasOptional(t => t.Asset)
                .WithMany(c => c.AssetDetails)
                .HasForeignKey(t => t.AssetId)
                .WillCascadeOnDelete(true);
        }
    }
}
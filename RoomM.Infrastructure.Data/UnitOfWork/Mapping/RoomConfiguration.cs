using RoomM.Domain.RoomModule.Aggregates;
using System.Data.Entity.ModelConfiguration;

namespace RoomM.Infrastructure.Data.UnitOfWork.Mapping
{
    public class RoomConfiguration : EntityTypeConfiguration<Room>
    {
        public RoomConfiguration()
        {
            // key
            this.HasKey(t => t.Id);

            // properties
            this.Property(t => t.Name).IsRequired();
            this.Property(t => t.RoomTypeId).IsOptional();
            this.Property(t => t.DateCreate);
            this.Property(t => t.IsUsing).IsRequired();
            this.Property(t => t.Description).IsOptional();

            // table
            this.ToTable("Rooms");

            // relationship
            this.HasOptional(t => t.RoomType)
                .WithMany(c => c.Rooms)
                .HasForeignKey(t => t.RoomTypeId)
                .WillCascadeOnDelete(true);
        }
    }
}
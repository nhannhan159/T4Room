using RoomM.Domain.RoomModule.Aggregates;
using System.Data.Entity.ModelConfiguration;

namespace RoomM.Infrastructure.Data.UnitOfWork.Mapping
{
    public class RoomTypeConfiguration : EntityTypeConfiguration<RoomType>
    {
        public RoomTypeConfiguration()
        {
            // key
            this.HasKey(t => t.Id);

            // properties
            this.Property(t => t.Name);

            // table
            this.ToTable("RoomTypes");
        }
    }
}
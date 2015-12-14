using RoomM.Domain.RoomModule.Aggregates;
using System.Data.Entity.ModelConfiguration;

namespace RoomM.Infrastructure.Data.UnitOfWork.Mapping
{
    public class RoomRegConfiguration : EntityTypeConfiguration<RoomReg>
    {
        public RoomRegConfiguration()
        {
            // key
            this.HasKey(t => t.Id);

            // properties
            this.Property(t => t.Date);
            this.Property(t => t.Start).IsRequired();
            this.Property(t => t.Length).IsRequired();
            this.Property(t => t.RoomId).IsOptional();
            this.Property(t => t.UserId).IsOptional();
            this.Property(t => t.RoomRegType).IsRequired();
            this.Property(t => t.IsWatched).IsOptional();

            // table
            this.ToTable("RoomRegs");

            // relationship
            this.HasOptional(t => t.Room)
                .WithMany(c => c.RoomRegs)
                .HasForeignKey(t => t.RoomId)
                .WillCascadeOnDelete(true);
            this.HasOptional(t => t.User)
                .WithMany(c => c.RoomRegs)
                .HasForeignKey(t => t.UserId)
                .WillCascadeOnDelete(true);
        }
    }
}
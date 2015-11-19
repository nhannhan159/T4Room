using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using RoomM.Domain.RoomModule.Aggregates;

namespace RoomM.Infrastructure.Data.UnitOfWork.Mapping
{
    public class RoomConfiguration : EntityTypeConfiguration<Room>
    {
        public RoomConfiguration()
        { 
            // key
            this.HasKey(t => t.Id);

            // properties
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
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

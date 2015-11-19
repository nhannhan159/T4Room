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
    public class RoomRegConfiguration : EntityTypeConfiguration<RoomReg>
    {
        public RoomRegConfiguration()
        { 
            // key
            this.HasKey(t => t.Id);

            // properties
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Date);
            this.Property(t => t.Start).IsRequired();
            this.Property(t => t.Length).IsRequired();
            this.Property(t => t.RoomId).IsOptional();
            this.Property(t => t.UserId).IsOptional();
            this.Property(t => t.RoomRegTypeId).IsRequired();
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

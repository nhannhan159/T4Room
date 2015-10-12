using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomM.Models.Mapping
{
    public class RoomCalendarMap : EntityTypeConfiguration<RoomCalendar>
    {
        public RoomCalendarMap()
        { 
            // key
            HasKey(t => t.ID);

            // properties
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Date);
            Property(t => t.Start).IsRequired();
            Property(t => t.Length).IsRequired();
            Property(t => t.RoomId).IsOptional(); 
            Property(t => t.StaffId).IsOptional();
            Property(t => t.IsWatched).IsOptional();
            Property(t => t.RoomCalendarStatusId).IsOptional();

            // table
            ToTable("RoomCalendars");

            // relationship
            HasOptional(t => t.RoomCalendarStatus).WithMany(c => c.RoomCalendars)
                .HasForeignKey(t => t.RoomCalendarStatusId).WillCascadeOnDelete(true);
            HasOptional(t => t.Room).WithMany(c => c.RoomCalendars)
                .HasForeignKey(t => t.RoomId).WillCascadeOnDelete(true);
            HasOptional(t => t.Staff).WithMany(c => c.RoomCalendars)
                .HasForeignKey(t => t.StaffId).WillCascadeOnDelete(true);
        }

    }
}

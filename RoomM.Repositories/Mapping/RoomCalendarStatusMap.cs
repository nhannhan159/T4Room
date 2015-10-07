using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using RoomM.Models.Rooms;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomM.Model.Mapping
{
    public class RoomCalendarStatusMap : EntityTypeConfiguration<RoomCalendarStatus>
    {
        public RoomCalendarStatusMap()
        { 
            
            // key 
            HasKey(t => t.ID);

            // properties
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name);

            // table
            ToTable("RoomCalendarStatuses");
        }

    }
}

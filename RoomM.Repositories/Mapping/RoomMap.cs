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
    public class RoomMap : EntityTypeConfiguration<Room>
    {
        public RoomMap()
        { 
            // key
            HasKey(t => t.ID);

            // properties
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name).IsRequired();
            Property(t => t.RoomTypeId).IsOptional();
            Property(t => t.DateCreate);
            Property(t => t.IsUsing).IsRequired();
            Property(t => t.Description).IsOptional();
            //Property(t => t.IsHaveRegistered).IsOptional();

            // table
            ToTable("Rooms");

            // relationship
            HasOptional(t => t.RoomType).WithMany(c => c.Rooms)
                .HasForeignKey(t => t.RoomTypeId).WillCascadeOnDelete(true);

        }

    }
}

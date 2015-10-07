using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using RoomM.Models.Staffs;

namespace RoomM.Model.Mapping
{
    public class StaffTypeMap : EntityTypeConfiguration<StaffType>
    {
        public StaffTypeMap()
        { 
            
            // key 
            HasKey(t => t.ID);

            // properties
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name);

            // table
            ToTable("StaffTypes");
        }

    }
}

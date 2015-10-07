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
    public class StaffMap : EntityTypeConfiguration<Staff>
    {
        public StaffMap()
        { 
            // key
            HasKey(t => t.ID);

            // properties
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.StaffTypeId).IsOptional();
            Property(t => t.Name).IsRequired();
            Property(t => t.Sex);
            Property(t => t.Phone);
            Property(t => t.UserName).IsRequired();
            Property(t => t.PasswordStored).IsRequired();
            Property(t => t.IsWorking).IsRequired();
            Property(t => t.Description).IsOptional();


            // table
            ToTable("Staffs");

            // relationship
            HasOptional(t => t.StaffType).WithMany(c => c.Staffs)
                .HasForeignKey(t => t.StaffTypeId).WillCascadeOnDelete(true);

        }

    }
}

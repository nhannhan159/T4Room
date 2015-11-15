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
    public class RoomRegTypeConfiguration : EntityTypeConfiguration<RoomRegType>
    {
        public RoomRegTypeConfiguration()
        { 
            // key 
            this.HasKey(t => t.ID);

            // properties
            this.Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Name);

            // table
            this.ToTable("RoomRegTypes");
        }

    }
}

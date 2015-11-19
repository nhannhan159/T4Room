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
    public class RoomTypeConfiguration : EntityTypeConfiguration<RoomType>
    {
        public RoomTypeConfiguration()
        {   
            // key 
            this.HasKey(t => t.Id);

            // properties
            this.Property(t => t.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Name);

            // table
            this.ToTable("RoomTypes");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;

using RoomM.Domain.AssetModule.Aggregates;

namespace RoomM.Infrastructure.Data.UnitOfWork.Mapping
{
    public class AssetHistoryTypeConfiguration : EntityTypeConfiguration<AssetHistoryType>
    {
        public AssetHistoryTypeConfiguration()
        { 
            // key 
            this.HasKey(t => t.ID);

            // properties
            this.Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Name);

            // table
            this.ToTable("AssetHistoryTypes");
        }
    }
}

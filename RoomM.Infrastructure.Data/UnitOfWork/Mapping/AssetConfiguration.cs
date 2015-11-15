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
    public class AssetConfiguration : EntityTypeConfiguration<Asset>
    {
        public AssetConfiguration()
        { 
            // key
            this.HasKey(t => t.ID);

            // properties
            this.Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            this.Property(t => t.Name).IsRequired();
            this.Property(t => t.IsUsing).IsRequired();
            this.Property(t => t.Description).IsOptional();

            // table
            this.ToTable("Assets");
        }
    }
}

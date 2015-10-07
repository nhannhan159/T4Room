using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.ModelConfiguration;
using System.ComponentModel.DataAnnotations.Schema;
using RoomM.Models.Assets;

namespace RoomM.Model.Mapping
{
    public class HistoryTypeMap : EntityTypeConfiguration<HistoryType>
    {
        public HistoryTypeMap()
        { 
            
            // key 
            HasKey(t => t.ID);

            // properties
            Property(t => t.ID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(t => t.Name);

            // table
            ToTable("HistoryTypes");
        }

    }
}

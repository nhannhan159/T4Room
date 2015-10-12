using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models
{
    public class HistoryType : EntityBase
    {
        public string Name { get; set; }
        public virtual ICollection<RoomAssetHistory> AssetHistories { get; set; }

        public HistoryType()
        {
            this.AssetHistories = new List<RoomAssetHistory>();
        }

        public HistoryType(string name)
        {
            this.Name = name;
            this.AssetHistories = new List<RoomAssetHistory>();
        }

        public HistoryType GetDetached()
        {
            HistoryType detached = new HistoryType();
            detached.ID = this.ID;
            detached.Name = this.Name;
            return detached;
        }
    }
}

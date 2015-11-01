using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RoomM.Models
{
    [DataContract]
    public class HistoryType : EntityBase
    {
        [DataMember]
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
    }
}

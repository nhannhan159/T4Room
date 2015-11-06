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
    public class Asset : EntityBase
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Boolean IsUsing { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public virtual ICollection<RoomAsset> RoomAssets { get; set; }

        [DataMember]
        public virtual ICollection<RoomAssetHistory> AssetHistories { get; set; }

        public string AllRoomName
        {
            get { return string.Join(",", this.RoomAssets.Select(p => p.Room.Name)); }
        }

        public int Amount
        {
            get { return this.RoomAssets.Sum(x => x.Amount); }
        }

        public override string ToString()
        {
            return this.ID + " # " + this.Name;
        }

        public Asset()
        {
            this.IsUsing = true;
            this.RoomAssets = new List<RoomAsset>();
            this.AssetHistories = new List<RoomAssetHistory>();
        }
    }
}

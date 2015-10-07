using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Assets
{
    public class Asset : EntityBase
    {
        public string Name { get; set; }
        public Boolean IsUsing { get; set; }
        public string Description { get; set; }

        public virtual ICollection<RoomAsset> RoomAssets { get; set; }
        public virtual ICollection<RoomAssetHistory> AssetHistories { get; set; }

        public int Amount
        {
            get { return this.RoomAssets.Sum(x => x.Amount); }
        }

        public string AllRoomName
        {
            get
            {
                string str = "";
                foreach (RoomAsset roomAss in RoomAssets)
                    str += roomAss.Room.Name;
                return str;
            }
        }

        public override string ToString()
        {
            return ID + " # " + Name;
        }

        public Asset()
        {
            this.IsUsing = true;
            this.RoomAssets = new List<RoomAsset>();
            this.AssetHistories = new List<RoomAssetHistory>();
        }

    }
}

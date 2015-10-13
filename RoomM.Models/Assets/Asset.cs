using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models
{
    public class Asset : Detachable<Asset>
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

        public override Asset GetDetached()
        {
            Asset detached = new Asset();
            detached.ID = this.ID;
            detached.Name = this.Name;
            detached.Description = this.Description;
            detached.IsUsing = this.IsUsing;
            /*
            List<RoomAsset> detachedRoomAssets = new List<RoomAsset>();
            List<RoomAsset> roomAssets = new List<RoomAsset>(this.RoomAssets);
            foreach (RoomAsset roomAsset in roomAssets)
            {
                detachedRoomAssets.Add(roomAsset.GetDetached());
            }
            detached.RoomAssets = this.RoomAssets;
             */
            return detached;
        }

    }
}

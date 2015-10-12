using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models
{
    public class RoomAssetHistory : EntityBase
    {
        public Int64 AssetHistoryTypeId { get; set; }
        public virtual HistoryType HistoryType { get; set; }
        
        public DateTime Date { get; set; }

        public Int64 AssetId { get; set; }
        public virtual Asset Asset { get; set; }

        public Int64 RoomId { get; set; }
        public virtual Room Room { get; set; }

        public string Room2 { get; set; }

        public int Amount { get; set; }

        public override string ToString()
        {
            return ID + " # " + " #type:" + AssetHistoryTypeId + " #roomID: " + RoomId;
        }

        public RoomAssetHistory(DateTime Date, Int64 AssetHistoryTypeId, Int64 AssetId, Int64 RoomId, string Room2, int Amount)
        {
            this.Date = Date;
            this.AssetHistoryTypeId = AssetHistoryTypeId;
            this.AssetId = AssetId;
            this.RoomId = RoomId;
            this.Room2 = Room2;
            this.Amount = Amount;
        }

        public RoomAssetHistory()
        {
        }

        public RoomAssetHistory GetDetached()
        {
            RoomAssetHistory detached = new RoomAssetHistory();
            detached.ID = this.ID;
            detached.AssetHistoryTypeId = this.AssetHistoryTypeId;
            detached.HistoryType = this.HistoryType.GetDetached();
            detached.Date = this.Date;
            detached.AssetId = this.AssetId;
            detached.Asset = this.Asset.GetDetached();
            detached.RoomId = this.RoomId;
            detached.Room = this.Room.GetDetached();
            detached.Room2 = this.Room2;
            detached.Amount = this.Amount;
            return detached;
        }
    }
}

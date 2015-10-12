using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RoomM.Models
{
    public class RoomAsset : Detachable<RoomAsset>
    {
        [Display(Name = "Mã phòng")]
        public Int64 RoomId { get; set; }
        public virtual Room Room { get; set; }

        public Int64 AssetId { get; set; }

        [Display(Name = "Thiết bị")]
        public virtual Asset Asset { get; set; }

        [Display(Name = "Số lượng")]
        public int Amount { get; set; }


        public override string ToString()
        {
            return ID + " #RoomId: " + RoomId + " #DeviceId: " + AssetId + " #amount: " + Amount;
        }

        public RoomAsset(Int64 AssetId, Int64 RoomId, int Amount)
        {
            this.AssetId = AssetId;
            this.RoomId = RoomId;
            this.Amount = Amount;
        }

        public RoomAsset()
        {
        }

        public override RoomAsset GetDetached()
        {
            RoomAsset detached = new RoomAsset();
            detached.ID = this.ID;
            detached.RoomId = this.RoomId;
            detached.Room = this.Room.GetDetached();
            detached.AssetId = this.AssetId;
            detached.Asset = this.Asset.GetDetached();
            detached.Amount = this.Amount;
            return detached;
        }

    }
}

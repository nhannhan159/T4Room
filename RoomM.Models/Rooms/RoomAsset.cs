using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RoomM.Models
{
    [DataContract]
    public class RoomAsset : EntityBase
    {
        [DataMember]
        [Display(Name = "Mã phòng")]
        public Int64 RoomId { get; set; }

        public virtual Room Room { get; set; }

        [DataMember]
        public Int64 AssetId { get; set; }

        [Display(Name = "Thiết bị")]
        public virtual Asset Asset { get; set; }

        [DataMember]
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
    }
}

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
    [DataContract(IsReference = true)]
    public class RoomAsset : EntityBase
    {
        [DataMember]
        [Display(Name = "Mã phòng")]
        public Int64 RoomId { get; set; }

        [DataMember]
        public virtual Room Room { get; set; }

        [DataMember]
        public Int64 AssetId { get; set; }

        [DataMember]
        [Display(Name = "Thiết bị")]
        public virtual Asset Asset { get; set; }

        [DataMember]
        [Display(Name = "Số lượng")]
        public int Amount { get; set; }

        public override string ToString()
        {
            return this.ID + " #RoomId: " + this.RoomId + " #DeviceId: " + this.AssetId + " #amount: " + this.Amount;
        }

        public RoomAsset()
        { }

        public RoomAsset(Int64 AssetId, Int64 RoomId, int Amount)
        {
            this.AssetId = AssetId;
            this.RoomId = RoomId;
            this.Amount = Amount;
        }
    }
}

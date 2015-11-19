using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using RoomM.Domain.RoomModule.Aggregates;

namespace RoomM.Domain.AssetModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class AssetHistory : EntityBase
    {
        public static int ASSETS_TRANSFER = 1;
        public static int ASSETS_REMOVE = 2;
        public static int ASSETS_IMPORT = 3;
        public static int ASSETS_RECEVIE = 4;

        public static Dictionary<int, string> GetHistoryType = new Dictionary<int, string>() {
	        { ASSETS_TRANSFER, "Chuyển thiết bị" },
            { ASSETS_REMOVE, "Thanh lí thiết bị" },
            { ASSETS_IMPORT, "Nhập thiết bị" },
            { ASSETS_RECEVIE, "Nhận thiết bị" }
        };

        [DataMember]
        public int AssetHistoryTypeId { get; set; }
        public string AssetHistoryType { get { return AssetHistory.GetHistoryType[this.AssetHistoryTypeId]; } }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public Int64 AssetId { get; set; }

        [DataMember]
        public virtual Asset Asset { get; set; }

        [DataMember]
        public Int64 RoomId { get; set; }

        [DataMember]
        public virtual Room Room { get; set; }

        [DataMember]
        public string Room2 { get; set; }

        [DataMember]
        public int Amount { get; set; }

        public override string ToString()
        {
            return this.Id + " # " + " #type:" + this.AssetHistoryTypeId + " #roomID: " + this.RoomId;
        }

        public AssetHistory() { }

        public AssetHistory(DateTime Date, int AssetHistoryTypeId, Int64 AssetId, Int64 RoomId, string Room2, int Amount)
        {
            this.Date = Date;
            this.AssetHistoryTypeId = AssetHistoryTypeId;
            this.AssetId = AssetId;
            this.RoomId = RoomId;
            this.Room2 = Room2;
            this.Amount = Amount;
        }
    }
}

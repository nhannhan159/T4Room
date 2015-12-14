using RoomM.Domain.RoomModule.Aggregates;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RoomM.Domain.AssetModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class AssetHistory : EntityBase
    {
        [DataMember]
        public int AssetHistoryType { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public string AssetId { get; set; }

        [DataMember]
        public virtual Asset Asset { get; set; }

        [DataMember]
        public string RoomId { get; set; }

        [DataMember]
        public virtual Room Room { get; set; }

        [DataMember]
        public string Room2 { get; set; }

        [DataMember]
        public int Amount { get; set; }

        public AssetHistory()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
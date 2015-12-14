using RoomM.Domain.RoomModule.Aggregates;
using System;
using System.Runtime.Serialization;

namespace RoomM.Domain.AssetModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class AssetDetail : EntityBase
    {
        [DataMember]
        public string RoomId { get; set; }

        [DataMember]
        public virtual Room Room { get; set; }

        [DataMember]
        public string AssetId { get; set; }

        [DataMember]
        public virtual Asset Asset { get; set; }

        [DataMember]
        public int Amount { get; set; }

        public AssetDetail()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
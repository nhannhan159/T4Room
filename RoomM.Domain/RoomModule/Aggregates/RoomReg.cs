using RoomM.Domain.UserModule.Aggregates;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace RoomM.Domain.RoomModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class RoomReg : EntityBase
    {
        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public int Start { get; set; }

        [DataMember]
        public int Length { get; set; }

        [DataMember]
        public string RoomId { get; set; }

        [DataMember]
        public virtual Room Room { get; set; }

        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public virtual User User { get; set; }

        [DataMember]
        public int RoomRegType { get; set; }

        [DataMember]
        public bool IsWatched { get; set; }

        public RoomReg()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
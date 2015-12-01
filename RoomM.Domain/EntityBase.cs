using System;
using System.Runtime.Serialization;

namespace RoomM.Domain
{
    [DataContract(IsReference = true)]
    public abstract class EntityBase
    {
        [DataMember]
        public Int64 Id { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;

namespace RoomM.Models
{
    [DataContract]
    public abstract class EntityBase
    {
        [DataMember]
        public Int64 ID { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RoomM.Domain
{
    [DataContract(IsReference = true)]
    public abstract class EntityBase
    {
        [DataMember]
        [StringLength(100)]
        public string Id { get; set; }
    }
}
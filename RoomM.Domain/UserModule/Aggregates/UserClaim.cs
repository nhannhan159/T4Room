using System;
using System.Runtime.Serialization;

namespace RoomM.Domain.UserModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class UserClaim : EntityBase
    {
        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public virtual User User { get; set; }

        [DataMember]
        public string ClaimType { get; set; }

        [DataMember]
        public string ClaimValue { get; set; }

        public UserClaim()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
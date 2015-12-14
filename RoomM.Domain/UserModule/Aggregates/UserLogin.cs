using System;
using System.Runtime.Serialization;

namespace RoomM.Domain.UserModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class UserLogin : EntityBase
    {
        [DataMember]
        public string UserId { get; set; }

        [DataMember]
        public virtual User User { get; set; }

        [DataMember]
        public string LoginProvider { get; set; }

        [DataMember]
        public string ProviderKey { get; set; }

        public UserLogin()
        {
            this.Id = Guid.NewGuid().ToString();
        }
    }
}
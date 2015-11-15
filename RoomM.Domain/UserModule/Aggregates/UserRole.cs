using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RoomM.Domain.UserModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class UserRole : EntityBase
    {
        [DataMember]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<User> Users
        {
            get
            {
                if (this.users == null)
                    this.users = new List<User>();
                return this.users;
            }
            set
            {
                this.users = new List<User>(value);
            }
        }

        private IList<User> users;

        public UserRole() { }

        public UserRole(string name)
        {
            this.Name = name;
        }
    }
}

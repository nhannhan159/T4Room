using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Microsoft.AspNet.Identity;

namespace RoomM.Domain.UserModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class Role : EntityBase, IRole<Int64>
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

        public Role() { }

        public Role(string name)
        {
            this.Name = name;
        }
    }
}

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

using RoomM.Domain.RoomModule.Aggregates;

namespace RoomM.Domain.UserModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class User : EntityBase, IUser<Int64>
    {
        [DataMember]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string FullName { get; set; }

        [DataMember]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        [DataMember]
        [DataType(DataType.Password)]
        public string PasswordHash { get; set; }

        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password
        {
            set { this.PasswordHash = (new PasswordHasher()).HashPassword(value); }
        }

        [DataMember]
        public Boolean IsWorking { get; set; }

        [DataMember]
        public bool Sex { get; set; }
        public string SexName { get { return this.Sex ? "Nữ" : "Nam"; } }

        [DataMember]
        [StringLength(15)]
        public string Phone { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public int AccessFailedCount { get; set; }

        [DataMember]
        public bool LockoutEnabled { get; set; }

        [DataMember]
        public DateTime? LockoutEndDateUtc { get; set; }

        [DataMember]
        public bool TwoFactorEnabled { get; set; }

        public virtual ICollection<Role> Roles
        {
            get
            {
                if (this.roles == null)
                    this.roles = new List<Role>();
                return this.roles;
            }
            set
            {
                this.roles = new List<Role>(value);
            }
        }

        public virtual ICollection<RoomReg> RoomRegs
        {
            get
            {
                if (this.roomRegs == null)
                    this.roomRegs = new List<RoomReg>();
                return this.roomRegs;
            }
            set
            {
                this.roomRegs = new List<RoomReg>(value);
            }
        }

        private IList<Role> roles;
        private IList<RoomReg> roomRegs;

        public User()
        {
            this.roles = new List<Role>();
            this.IsWorking = true;
        }

        public override string ToString()
        {
            return this.Id + " #name " + this.FullName + " #username " + this.UserName + " #pass " + this.PasswordHash;
        }
    }
}

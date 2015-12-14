using Microsoft.AspNet.Identity;
using RoomM.Domain.RoomModule.Aggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace RoomM.Domain.UserModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class User : EntityBase, IUser<string>
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
        public string PasswordHash { get; set; }

        [DataMember]
        public Boolean IsWorking { get; set; }

        [DataMember]
        public bool Sex { get; set; }

        [DataMember]
        [StringLength(15)]
        public string Phone { get; set; }

        [DataMember]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime LastLogin { get; set; }

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

        [DataMember]
        public string SecurityStamp { get; set; }

        [DataMember]
        public string RoleId { get; set; }

        [DataMember]
        public virtual Role Role { get; set; }

        public virtual ICollection<UserClaim> UserClaims
        {
            get
            {
                if (this.userClaims == null)
                    this.userClaims = new List<UserClaim>();
                return this.userClaims;
            }
            set
            {
                this.userClaims = new List<UserClaim>(value);
            }
        }

        public virtual ICollection<UserLogin> UserLogins
        {
            get
            {
                if (this.userLogins == null)
                    this.userLogins = new List<UserLogin>();
                return this.userLogins;
            }
            set
            {
                this.userLogins = new List<UserLogin>(value);
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

        private IList<UserClaim> userClaims;
        private IList<UserLogin> userLogins;
        private IList<RoomReg> roomRegs;

        public User()
        {
            this.Id = Guid.NewGuid().ToString();
            this.IsWorking = true;
        }
    }
}
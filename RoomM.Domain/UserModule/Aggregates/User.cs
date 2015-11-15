using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using RoomM.Domain.RoomModule.Aggregates;
using RoomM.Domain.Utils;

namespace RoomM.Domain.UserModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class User : EntityBase
    {
        [DataMember]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        [DataMember]
        public bool Sex { get; set; }

        public string SexName
        {
            get { return this.Sex ? "Nữ" : "Nam"; }
        }

        [DataMember]
        [StringLength(15)]
        public string Phone { get; set; }

        [DataMember]
        public Int64 UserRoleId { get; set; }

        [DataMember]
        public virtual UserRole UserRole { get; set; }

        [DataMember]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        [DataMember]
        [StringLength(30, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string PasswordStored { get; set; }

        [NotMapped]
        public string Password
        {
            get { return CryptorEngine.Decrypt(PasswordStored, true); }
            set { PasswordStored = CryptorEngine.Encrypt(value, true); }
        }

        [DataMember]
        public Boolean IsWorking { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        [Display(Name = "Lan cuoi dang nhap")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastLogin { get; set; }

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

        private IList<RoomReg> roomRegs;

        public User()
        {
            this.IsWorking = true;
        }

        public override string ToString()
        {
            return this.ID + " #name " + this.Name + " #username " + this.UserName + " #pass " + this.PasswordStored + "#realpass " + this.Password;
        }
    }
}

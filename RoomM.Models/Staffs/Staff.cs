using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RoomM.Models
{
    [DataContract]
    public class Staff : EntityBase
    {
        [DataMember]
        [StringLength(50)]
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
        public Int64 StaffTypeId { get; set; }

        public virtual StaffType StaffType { get; set; }

        [DataMember]
        [StringLength(50)]
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

        public virtual ICollection<RoomCalendar> RoomCalendars { get; set; }

        public override string ToString()
        {
            return ID + " #name " + Name + " #username " + UserName + " #pass " + PasswordStored + "#realpass " + Password;
        }

        public Staff()
        {
            this.IsWorking = true;
            this.RoomCalendars = new List<RoomCalendar>();
        }
    }
}

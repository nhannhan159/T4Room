using RoomM.Models.Devices;
using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Users
{
    public class User : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }

        public bool Sex { get; set; }

        [StringLength(15)]
        public string Phone { get; set; }

        public Int64 UserTypeId { get; set; }

        public virtual UserType UserType { get; set; }

        [StringLength(50)]
        public string UserName { get; set; }

        [StringLength(30, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string PasswordStored { get; set; }

        [NotMapped]
        public string Password
        {
            get { return CryptorEngine.Decrypt(PasswordStored, true); }
            set { PasswordStored = CryptorEngine.Encrypt(value, true); }
        }

        public Boolean IsWorking { get; set; }

        [Display(Name = "Lan cuoi dang nhap")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime LastLogin { get; set; }

        public virtual ICollection<RoomCalendar> RoomCalendars { get; set; }

        public override string ToString()
        {
            return ID + " #name " + Name + " #username " + UserName + " #pass " + PasswordStored + "#realpass " + Password;
        }
    }
}

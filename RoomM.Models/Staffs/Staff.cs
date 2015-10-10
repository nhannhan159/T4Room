using RoomM.Models.Rooms;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoomM.Models.Staffs
{
    public class Staff : EntityBase
    {
        [StringLength(50)]
        public string Name { get; set; }

        public bool Sex { get; set; }

        public string SexName
        {
            get { return this.Sex ? "Nữ" : "Nam"; }
        }

        [StringLength(15)]
        public string Phone { get; set; }

        public Int64 StaffTypeId { get; set; }

        public virtual StaffType StaffType { get; set; }

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

        public string Description { get; set; }

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

        public Staff GetDetached()
        {
            Staff detached = new Staff();
            detached.ID = this.ID;
            detached.Name = this.Name;
            detached.Sex = this.Sex;
            detached.Phone = this.Phone;
            detached.StaffTypeId = this.StaffTypeId;
            detached.StaffType = this.StaffType.GetDetached();
            detached.UserName = this.UserName;
            detached.PasswordStored = this.PasswordStored;
            detached.IsWorking = this.IsWorking;
            detached.Description = this.Description;
            detached.LastLogin = this.LastLogin;
            return detached;
        }
    }
}

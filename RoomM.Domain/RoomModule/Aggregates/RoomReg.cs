using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

using RoomM.Domain.UserModule.Aggregates;

namespace RoomM.Domain.RoomModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class RoomReg : EntityBase
    {
        [DataMember]
        [DataType(DataType.Date)]
        [Display(Name = "Ngày đăng kí")]
        public DateTime Date { get; set; }

        [DataMember]
        [Display(Name = "Tiết bắt đầu")]
        public int Start { get; set; }

        [DataMember]
        [Display(Name = "Số tiết")]
        public int Length { get; set; }

        [DataMember]
        [Display(Name = "Mã phòng")]
        public Int64 RoomId { get; set; }

        [DataMember]
        public virtual Room Room { get; set; }

        [DataMember]
        public Int64 UserId { get; set; }

        [DataMember]
        public virtual User User { get; set; }

        [DataMember]
        public Int64 RoomRegTypeId { get; set; }

        [DataMember]
        [Display(Name = "Trạng thái đăng kí")]
        public virtual RoomRegType RoomRegType { get; set; }

        [DataMember]
        public bool IsWatched { get; set; }

        public override string ToString()
        {
            return this.ID + " #room " + this.RoomId + " #user " + this.UserId + " #start " + this.Start + " #len " + this.Length;
        }
    }
}

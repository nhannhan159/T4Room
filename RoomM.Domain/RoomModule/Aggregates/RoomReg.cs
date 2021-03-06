﻿using RoomM.Domain.UserModule.Aggregates;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RoomM.Domain.RoomModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class RoomReg : EntityBase
    {
        public static int REG_WAITING = 1;
        public static int REG_COMFIRMED = 2;
        public static int REG_CANCELED = 3;

        public static Dictionary<int, string> GetRegType = new Dictionary<int, string>() {
            { REG_WAITING  , "Chờ xác nhận" },
            { REG_COMFIRMED, "Đã đăng ký" },
            { REG_CANCELED , "Hủy đăng ký" }
        };

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
        public int RoomRegTypeId { get; set; }

        [Display(Name = "Trạng thái đăng kí")]
        public string RoomRegType { get { return RoomReg.GetRegType[this.RoomRegTypeId]; } }

        [DataMember]
        public bool IsWatched { get; set; }

        public override string ToString()
        {
            return this.Id + " #room " + this.RoomId + " #user " + this.UserId + " #start " + this.Start + " #len " + this.Length;
        }
    }
}
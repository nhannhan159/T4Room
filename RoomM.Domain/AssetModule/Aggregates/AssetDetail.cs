﻿using RoomM.Domain.RoomModule.Aggregates;
using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace RoomM.Domain.AssetModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class AssetDetail : EntityBase
    {
        [DataMember]
        [Display(Name = "Mã phòng")]
        public Int64 RoomId { get; set; }

        [DataMember]
        public virtual Room Room { get; set; }

        [DataMember]
        public Int64 AssetId { get; set; }

        [DataMember]
        [Display(Name = "Thiết bị")]
        public virtual Asset Asset { get; set; }

        [DataMember]
        [Display(Name = "Số lượng")]
        public int Amount { get; set; }

        public AssetDetail()
        {
        }

        public AssetDetail(Int64 AssetId, Int64 RoomId, int Amount)
        {
            this.AssetId = AssetId;
            this.RoomId = RoomId;
            this.Amount = Amount;
        }

        public override string ToString()
        {
            return this.Id + " #RoomId: " + this.RoomId + " #DeviceId: " + this.AssetId + " #amount: " + this.Amount;
        }
    }
}
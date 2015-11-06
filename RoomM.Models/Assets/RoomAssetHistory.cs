﻿using System;
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
    public class RoomAssetHistory : EntityBase
    {
        [DataMember]
        public Int64 AssetHistoryTypeId { get; set; }

        [DataMember]
        public virtual HistoryType HistoryType { get; set; }

        [DataMember]
        public DateTime Date { get; set; }

        [DataMember]
        public Int64 AssetId { get; set; }

        [DataMember]
        public virtual Asset Asset { get; set; }

        [DataMember]
        public Int64 RoomId { get; set; }

        [DataMember]
        public virtual Room Room { get; set; }

        [DataMember]
        public string Room2 { get; set; }

        [DataMember]
        public int Amount { get; set; }

        public override string ToString()
        {
            return this.ID + " # " + " #type:" + this.AssetHistoryTypeId + " #roomID: " + this.RoomId;
        }

        public RoomAssetHistory()
        { }

        public RoomAssetHistory(DateTime Date, Int64 AssetHistoryTypeId, Int64 AssetId, Int64 RoomId, string Room2, int Amount)
        {
            this.Date = Date;
            this.AssetHistoryTypeId = AssetHistoryTypeId;
            this.AssetId = AssetId;
            this.RoomId = RoomId;
            this.Room2 = Room2;
            this.Amount = Amount;
        }
    }
}

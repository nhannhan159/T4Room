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
    [DataContract(IsReference = true)]
    public class RoomType : EntityBase
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public virtual ICollection<Room> Rooms { get; set; }

        public RoomType()
        {
            this.Rooms = new List<Room>();
        }

        public RoomType(string name)
        {
            this.Name = name;
            this.Rooms = new List<Room>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace RoomM.Domain.RoomModule.Aggregates
{
    [DataContract(IsReference = true)]
    public class RoomType : EntityBase
    {
        [DataMember]
        [StringLength(50)]
        [Index(IsUnique = true)]
        public string Name { get; set; }

        public virtual ICollection<Room> Rooms
        {
            get
            {
                if (this.rooms == null)
                    this.rooms = new List<Room>();
                return this.rooms;
            }
            set
            {
                this.rooms = new List<Room>(value);
            }
        }

        private IList<Room> rooms;

        public RoomType() { }

        public RoomType(string name)
        {
            this.Name = name;
        }
    }
}

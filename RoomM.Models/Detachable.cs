using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RoomM.Models
{
    public abstract class Detachable<T> : EntityBase where T : EntityBase, new()
    {
        public abstract T GetDetached();
    }
}

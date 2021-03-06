using Entities.Abctract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class RoomImage:IEntity
    {
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
    }
}


using Entities.Abctract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class RoomTypeImage : IEntity
    {
        public int ID { get; set; }
        public string ImageUrl { get; set; }
        public int RoomTypeId { get; set; }
        public virtual RoomType RoomType { get; set; }
    }
}

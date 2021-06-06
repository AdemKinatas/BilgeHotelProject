using Entities.Abctract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class RoomType:IEntity
    {
        public int ID { get; set; }
        public string RoomTypeName { get; set; }
        public decimal BasePrice { get; set; }
        public virtual List<RoomTypeImage> RoomTypeImages { get; set; }
    }
}

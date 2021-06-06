using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcWebUI.Models
{
    public class RoomFilterListVM
    {
        public List<Room> Rooms { get; set; }
        public List<RoomImage> RoomImages { get; set; }
        public RoomType RoomType { get; set; }
    }
}

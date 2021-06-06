using Entities.Abctract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RoomListDto : IDto
    {
        public List<RoomType> RoomTypes { get; set; }
        public List<RoomStatus> RoomStatuses { get; set; }
        public List<Room> Rooms { get; set; }
        public List<RoomImage> RoomImages { get; set; }
    }
}

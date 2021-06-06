using Entities.Abctract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RoomFilterListDto : IDto
    {
        public List<Room> Rooms { get; set; }
        public List<RoomImage> RoomImages { get; set; }
        public RoomType RoomType { get; set; }
    }
}

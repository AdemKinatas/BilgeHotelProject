using Entities.Abctract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class RoomTypeDetailListDto : IDto
    {
        public List<RoomType> RoomTypes { get; set; }
        public List<RoomTypeImage> RoomTypeImages { get; set; }
    }
}

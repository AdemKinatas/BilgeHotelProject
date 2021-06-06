using Entities.Abctract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class BookingFilter : IDto
    {
        public int RoomTypeId { get; set; }
        public DateTime BookingFrom { get; set; } = DateTime.Now;
        public DateTime BookingTo { get; set; } = DateTime.Now;
    }
}

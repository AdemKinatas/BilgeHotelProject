using Entities.Abctract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class BookingListDto : IDto
    {
        public List<Booking> Bookings { get; set; }
        public List<BookingPackage> BookingPackages { get; set; }
        public List<Room> Rooms { get; set; }
    }
}

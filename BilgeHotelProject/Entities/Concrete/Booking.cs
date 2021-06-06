using Entities.Abctract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public partial class Booking:IEntity
    {
        public Booking()
        {
            BookingFrom = BookingFrom.AddHours(14);
            BookingTo = BookingTo.AddHours(10);
        }
        public int ID { get; set; }
        public string PersonName { get; set; }
        public string PersonLastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime BookingFrom { get; set; }
        public DateTime BookingTo { get; set; }
        public decimal TotalAmount { get; set; }
        public int NoOfGuests { get; set; }
        public bool IsPaid { get; set; } = false;
        public int RoomId { get; set; }
        public virtual Room Room { get; set; }
        public int BookingPackageId { get; set; }
        public virtual BookingPackage BookingPackage { get; set; }
        public int AppUserId { get; set; }
        public virtual AppUser AppUser { get; set; }
    }
}

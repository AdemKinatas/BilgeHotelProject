using Entities.Abctract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Payment:IEntity
    {
        public int ID { get; set; }
        public decimal ExtraPrice { get; set; } = 0;
        public decimal PaymentAmount { get; set; }
        public int BookingId { get; set; }
        public virtual Booking Booking { get; set; }
        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }
    }
}

using Entities.Abctract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DTOs
{
    public class PaymentListDto : IDto
    {
        public List<Payment> Payments { get; set; }
        public List<PaymentType> PaymentTypes { get; set; }
        public List<Booking> Bookings { get; set; }
    }
}

using Entities.Abctract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PaymentType:IEntity
    {
        public int ID { get; set; }
        public string PaymentTypeName { get; set; }
    }
}

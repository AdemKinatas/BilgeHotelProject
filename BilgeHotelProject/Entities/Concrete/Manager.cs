using Entities.Abctract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Manager : IEntity
    {
        public Manager()
        {

        }

        public int ID { get; set; }
        public string NationalIdentificationNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; } 
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public int DutyId { get; set; }
        public virtual Duty Duty { get; set; }
        public virtual List<PayrollForManager> PayrollForManagers { get; set; }
    }
}

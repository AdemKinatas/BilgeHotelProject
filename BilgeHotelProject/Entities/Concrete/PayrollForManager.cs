using Entities.Abctract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PayrollForManager : IEntity
    {
        public int ID { get; set; }
        public DateTime SalaryDate { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public int ManagerId { get; set; }
        public virtual Manager Manager { get; set; }
    }
}

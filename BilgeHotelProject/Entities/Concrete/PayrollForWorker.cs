using Entities.Abctract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class PayrollForWorker : IEntity
    {
        public int ID { get; set; }
        public DateTime SalaryDate { get; set; }
        public string Description { get; set; }
        public decimal Salary { get; set; }
        public int WorkerId { get; set; }
        public virtual Worker Worker { get; set; }
        public decimal HourlyFee { get; set; }
        public short DailyWorkingHours { get; set; }
        public short TotalWorkingDaysPerMonth { get; set; }
        public short Overtime { get; set; }
    }
}

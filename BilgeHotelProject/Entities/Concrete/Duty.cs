using Entities.Abctract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Duty:IEntity
    {
        public int ID { get; set; }
        public string DutyName { get; set; }
        public string Description { get; set; }
    }
}

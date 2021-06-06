using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MvcUI.Models
{
    public class SearchFilterModel
    {
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public int NoOfGuest { get; set; }
        public int? RoomTypeId { get; set; }
    }
}

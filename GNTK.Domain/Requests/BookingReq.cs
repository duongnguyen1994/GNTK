using System;
using System.Collections.Generic;
using System.Text;

namespace GNTK.Domain.Requests
{
   public class BookingReq
    {
        public string BookingId { get; set; }
        public string PickedUpLocation { get; set; }
        public string DropedOffLocation { get; set; }
        public decimal Distance { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime BookingTime { get; set; }
        public DateTime PickedUpTime { get; set; }
        public DateTime DroppedOffTime { get; set; }



    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace GNTK.Domain.Responses
{
    public class BookingTransportRes
    {
        public string BookingId { get; set; }
        public string Message { get; set; }
        public decimal Distance { get; set; }
        public decimal UnitPrince { get; set; }
    }
}

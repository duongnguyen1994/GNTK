using System;
using System.Collections.Generic;
using System.Text;

namespace GNTK.Domain.Responses
{
    public class BookingsAroundRes
    {
        public string BookingId { get; set; }
        public decimal InRadius { get; set; }
    }
}

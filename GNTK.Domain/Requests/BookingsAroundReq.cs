using System;
using System.Collections.Generic;
using System.Text;

namespace GNTK.Domain.Requests
{
    public class BookingsAroundReq
    {
        public string DriverId { get; set; }
        public decimal InRadius { get; set; }
    }
}

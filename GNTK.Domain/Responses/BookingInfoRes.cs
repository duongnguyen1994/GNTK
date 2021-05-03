using System;
using System.Collections.Generic;
using System.Text;

namespace GNTK.Domain.Responses
{
    public class BookingInfoRes
    {
        public string BookingId { get; set; }
        public decimal Distance { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime BookingTime { get; set; }
        public DateTime PickedUpTime { get; set; }
        public DateTime DroppedOffTime { get; set; }
        public string CustomerId { get; set; }
        public string DriverId { get; set; }
        public string CommentId { get; set; }
        public string DiscountId { get; set; }
        public decimal PickedUpLatitude { get; set; }
        public decimal PickedUpLongtitude { get; set; }
        public decimal DropedOffLatitude { get; set; }
        public decimal DropedOffLongtitude { get; set; }   
        public bool IsCancel { get; set; }
    }
}

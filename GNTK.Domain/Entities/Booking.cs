using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GNTK.Domain.Entities
{
    public class Booking
    {
        [Key]
        [Required]
        [MaxLength(450)]
        public string BookingId { get; set; }
        [Required]
        public decimal PickedUpLatitude{ get; set; }
        [Required]
        public decimal PickedUpLongtitude { get; set; }
        [Required]
        public decimal DropedOffLatitude { get; set; }
        [Required]
        public decimal DropedOffLongtitude{ get; set; }
        [Required]
        public Decimal Distance { get; set; }
        [Required]
        public Decimal UnitPrice { get; set; }
        [Required]
        public DateTime BookingTime { get; set; }
        public DateTime PickedUpTime { get; set; }
        public DateTime DroppedOffTime { get; set; }
        public string CustomerId { get; set; }
        public AppIdentityUser Customer { get; set; }
        public string DriverId { get; set; }
        public AppIdentityUser Driver { get; set; }
        [ForeignKey("Comment")]
        public string CommentId { get; set; }
        public virtual Comment Comment { get; set; }
        [ForeignKey("Discount")]
        public string DiscountId { get; set; }
        public virtual Discount Discount { get; set; }
        public bool IsCancel { get; set; }
    }
}

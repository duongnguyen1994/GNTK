using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GNTK.Domain.Entities
{
    public class Discount
    {
        [Key]
        [Required]
        [MaxLength(450)]
        public string DiscountId { get; set; }
        [Required]
        [MaxLength(20)]
        public string Code { get; set; }
        [Required]
        public DateTime ExpiryDate { get; set; }
        [Required]
        public float Value { get; set; }
        public virtual Booking Booking { get; set; }
    }
}

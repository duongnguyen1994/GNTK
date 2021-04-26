using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GNTK.Domain.Entities
{
    public class AppIdentityUser : IdentityUser
    {
        [Required]
        [MaxLength(100)]
        public string Fullname { get; set; }
        [MaxLength(500)]
        public string Avatar { get; set; }
        [MaxLength(20)]
        public string IdentityCardNumber { get; set; }
        [MaxLength(20)]
        public string DrivingLicenseNumber { get; set; }
        [Required]
        [MaxLength(100)]
        public string Address { get; set; }
        [Required]
        public bool Status { get; set; } // check status of driver(true: on, ready to accept booking, false: off)
        public decimal Latitude { get; set; }
        public decimal Longtitude { get; set; }
        [Required]
        public DateTime JoinDate { get; set; }
        [Required]
        public bool IsDelete { get; set; }
        public int WardId { get; set; }
        public int DistrictId { get; set; }
        public int ProvinceId { get; set; }
        public int CountryId { get; set; }
        public virtual Vehicle Vehicle { get; set; }
        public ICollection<Booking> CustomerBookings { get; set; }
        public ICollection<Booking> DriverBookings { get; set; }
    }
}

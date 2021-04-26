using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GNTK.Domain.Entities
{
    public class Vehicle
    {
        [Key]
        [Required]
        [MaxLength(450)]
        public string VehicleId { get; set; }
        [Required]
        [MaxLength(10)]
        public string VehicleRegistrationCertificateNumber { get; set; }
        [Required]
        [MaxLength(20)]
        public string Brand { get; set; }
        [Required]
        [MaxLength(20)]
        public string Color { get; set; }
        [Required]
        [MaxLength(15)]
        public string NumberPlate { get; set; }
        [ForeignKey("Driver")]
        public string DriverId { get; set; }
        public virtual AppIdentityUser Driver { get; set; }
    }
}

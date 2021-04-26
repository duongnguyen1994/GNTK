using System;
using System.Collections.Generic;
using System.Text;

namespace GNTK.Domain.Requests
{
    public class DriverRegisterReq
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string PhoneNumber { get; set; }
        public string Fullname { get; set; }
        public string Avatar { get; set; }       
        public string IdentityCardNumber { get; set; }
        public string DrivingLicenseNumber { get; set; }
        public int Ward { get; set; }
        public int District { get; set; }
        public int Province { get; set; }
        public int Country { get; set; }
        public string Address { get; set; }
        public VehicleReq Vehicle { get; set; }
    }
}

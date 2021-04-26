using System;
using System.Collections.Generic;
using System.Text;

namespace GNTK.Domain.Requests
{
    public class VehicleReq
    {
        public string VehicleRegistrationCertificateNumber { get; set; }
        public string Brand { get; set; }
        public string Color { get; set; }
        public string NumberPlate { get; set; }
    }
}

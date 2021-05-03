using GNTK.BAL.Interface;
using GNTK.Domain.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNTK.API.Controllers
{
    public class DriverController : BaseController
    {
        private readonly IDriverService driverService;

        public DriverController(IDriverService driverService)
        {
            this.driverService = driverService;
        }
        [HttpPut]
        [Route("AcceptBooking")]
        public async Task<IActionResult> AcceptBooking(BookingReq request)
        {
            return Ok(await driverService.AcceptBooking(request));
        }
        [HttpPut]
        [Route("ChangeDriverStatus")]
        public async Task<IActionResult> ChangeDriverStatus(string driverId)
        {
            return Ok(await driverService.ChangeDriverStatus(driverId));
        }
        [HttpPut]
        [Route("DropedOffCustomer")]
        public async Task<IActionResult> DropedOffCustomer(BookingReq request)
        {
            return Ok(await driverService.DropedOffCustomer(request));
        }
        [HttpPut]
        [Route("PickedUpCustomer")]
        public async Task<IActionResult> PickedUpCustomer(BookingReq request)
        {
            return Ok(await driverService.PickedUpCustomer(request));
        }
        [HttpGet]
        [Route("GetDriverById")]
        public async Task<IActionResult> GetDriverById(string driverId)
        {
            return Ok(await driverService.GetDriverById(driverId));
        }
    }
}

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
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController: ControllerBase
    {
        private readonly IBookingService bookingService;
        //private readonly ICustomerService customerService;

        public CustomerController(IBookingService bookingService
                               )
        {
            this.bookingService = bookingService;
      
        }
        [HttpPost]
        [Route("CreateBookings")]
        public async Task<IActionResult> CreateBooking(BookingReq req)
        {
            return Ok(await bookingService.CreateBooking(req));
        }
      
    }
}

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
    public class BookingController : BaseController
    {
        private readonly IBookingService bookingService;

        public BookingController(IBookingService bookingService)
        {
            this.bookingService = bookingService;
        }
        [HttpGet]
        [Route("GetBookingsAround")]
        public async Task<IActionResult> GetBookingsAround(BookingsAroundReq request)
        {
            return Ok(await bookingService.GetBookingsAround(request));
        }
        [HttpPost]
        [Route("BookingTransport")]
        public async Task<IActionResult> BookingTransport(BookingTransportReq request)
        {
            return Ok(await bookingService.BookingTransport(request));
        }
        [HttpGet]
        [Route("GetBookingById")]
        public async Task<IActionResult> GetBookingById(string bookingId)
        {
            return Ok(await bookingService.GetBookingById(bookingId));
        }
    }
}

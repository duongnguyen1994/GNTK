using GNTK.BAL.Interface;
using GNTK.DAL.Interface;
using GNTK.Domain.Requests;
using GNTK.Domain.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GNTK.BAL.Implement
{
   public class BookingService:IBookingService
    {
        private readonly IBookingRepository bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }
        public async Task<BookingRegisterRes> CreateBooking(BookingReq request)
        {
            try
            {
                var result = await bookingRepository.CreateBooking(request);
                if (!String.IsNullOrEmpty(result.Id))
                {
                    return result;
                }
                result.Id = "";
                result.Message = "Something went wrong please try again";
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

    


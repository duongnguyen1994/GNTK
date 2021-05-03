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
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            this.bookingRepository = bookingRepository;
        }

        public async Task<BookingTransportRes> BookingTransport(BookingTransportReq request)
        {
            try
            {
                if (request != null)
                    return await bookingRepository.BookingTransport(request);
                return new BookingTransportRes()
                {
                    BookingId = "",
                    Message = "Có lỗi xảy ra, xin hãy liên hệ với tổng đài để khắc phục"
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<BookingInfoRes> GetBookingById(string bookingId)
        {
            try
            {
                if (!String.IsNullOrEmpty(bookingId))
                    return await bookingRepository.GetBookingById(bookingId);
                return new BookingInfoRes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<BookingsAroundRes>> GetBookingsAround(BookingsAroundReq request)
        {
            try
            {
                if (request != null)
                {
                    return await bookingRepository.GetBookingsAround(request);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using Dapper;
using GNTK.DAL.Interface;
using GNTK.Domain.Requests;
using GNTK.Domain.Responses;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace GNTK.DAL.Implement
{
    public class BookingRepository : BaseRepository, IBookingRepository
    {

        public BookingRepository(IConfiguration configuration) : base(configuration)
        {

        }

        public async Task<BookingTransportRes> BookingTransport(BookingTransportReq request)
        {
            try
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@CustomerId", request.CustomerId);
                parameters.Add("@DiscountId", request.DiscountId);
                parameters.Add("@Distance", request.Distance);
                parameters.Add("@UnitPrice", request.UnitPrice);
                parameters.Add("@PickedUpLatitude", request.PickedUpLatitude);
                parameters.Add("@PickedUpLongtitude", request.PickedUpLongtitude);
                parameters.Add("@DropedOffLatitude", request.DropedOffLatitude);
                parameters.Add("@DropedOffLongtitude", request.DropedOffLongtitude);
                return await SqlMapper.QueryFirstAsync<BookingTransportRes>(
                                                cnn: connection,
                                                sql: "sp_BookingTransport",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure);
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
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@BookingId", bookingId);
                return await SqlMapper.QueryFirstAsync<BookingInfoRes>(
                                                cnn: connection,
                                                sql: "sp_GetBookingById",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure);
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
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@DriverId", request.DriverId);
                parameters.Add("@InRadius", request.InRadius);
                return await SqlMapper.QueryAsync<BookingsAroundRes>(
                                                cnn: connection,
                                                sql: "sp_PickedUpCustomer",
                                                param: parameters,
                                                commandType: CommandType.StoredProcedure);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using Dapper;
using GNTK.DAL.Interface;
using GNTK.Domain.Entities;
using GNTK.Domain.Requests;
using GNTK.Domain.Responses;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<AppIdentityUser> userManager;

        public BookingRepository(IConfiguration config,
                                      UserManager<AppIdentityUser> userManager) : base(config)
        {
            this.userManager = userManager;
        }

        public async Task<BookingRegisterRes> CreateBooking(BookingReq request)
        {

            DynamicParameters parameters = new DynamicParameters();
            parameters.Add("@BookingId", request.BookingId);
            parameters.Add("@PickedUpLocation", request.PickedUpLocation);
            parameters.Add("@DropedOffLocation", request.DropedOffLocation);
            parameters.Add("@Distance", request.Distance);
            parameters.Add("@UnitPrice", request.UnitPrice);
            parameters.Add("@BookingTime", request.BookingTime);
            parameters.Add("@PickedUpTime", request.PickedUpTime);
            parameters.Add("@DroppedOffTime", request.DroppedOffTime);
            var newBooking = await SqlMapper.QueryFirstAsync<BookingRegisterRes>(
                                                     cnn: connection,
                                                     sql: "SP_CreateBookings",
                                                     param: parameters,
                                                     commandType: CommandType.StoredProcedure);
            return newBooking;


        }
    }
}
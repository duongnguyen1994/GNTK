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
    public class DriverRepository : BaseRepository, IDriverRepository
    {
        private readonly UserManager<AppIdentityUser> userManager;

        public DriverRepository(IConfiguration configuration, 
            UserManager<AppIdentityUser> userManager) : base(configuration)
        {
            this.userManager = userManager;
        }
        public async Task<DriverRegisterRes> CreateDriver(DriverRegisterReq request)
        {
            try
            {
                if (request != null)
                {
                    var driver = new AppIdentityUser()
                    {
                        Email = request.Email,
                        UserName = request.Email,
                        PhoneNumber = request.PhoneNumber,
                        Fullname = request.Fullname,
                        Avatar = request.Avatar,
                        IdentityCardNumber = request.IdentityCardNumber,
                        DrivingLicenseNumber = request.DrivingLicenseNumber,
                        WardId = request.Ward,
                        DistrictId = request.District,
                        ProvinceId = request.Province,
                        CountryId = request.Country,
                        JoinDate = DateTime.Now,
                        Address = request.Address
                    };
                    var result = await userManager.CreateAsync(driver, request.Password);
                    if (result.Succeeded)
                    {
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("@UserId", driver.Id);
                        parameters.Add("@RoleId", "2");
                        var newDriver = await SqlMapper.QueryFirstAsync<DriverRegisterRes>(
                                                        cnn: connection,
                                                        sql: "sp_AddRoleToUser",
                                                        param: parameters,
                                                        commandType: CommandType.StoredProcedure);
                        if (newDriver.Message == "Successful!")
                        {
                            DynamicParameters paras = new DynamicParameters();
                            paras.Add("@DriverId", driver.Id);
                            paras.Add("@VehicleRegistrationCertificateNumber", request.Vehicle.VehicleRegistrationCertificateNumber);
                            paras.Add("@Brand", request.Vehicle.Brand);
                            paras.Add("@Color", request.Vehicle.Color);
                            paras.Add("@NumberPlate", request.Vehicle.NumberPlate);
                            var vehicle = await SqlMapper.QueryFirstAsync<bool>(
                                                            cnn: connection,
                                                            sql: "[dbo].[sp_AddDriverVehicle]",
                                                            param: paras,
                                                            commandType: CommandType.StoredProcedure);
                            if (vehicle)
                                return newDriver;
                        }
                    }              
                }
                return new DriverRegisterRes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

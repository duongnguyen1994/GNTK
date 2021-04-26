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
    public class CustomerRepository : BaseRepository, ICustomerRepository
    {
        private readonly UserManager<AppIdentityUser> userManager;

        public CustomerRepository(IConfiguration config,
                                    UserManager<AppIdentityUser> userManager) : base(config)
        {
            this.userManager = userManager;
        }

        public async Task<CustomerRegisterRes> CreateCustomer(CustomerRegisterReq request)
        {
            try
            {
                if(request!=null)
                {
                    var customer = new AppIdentityUser()
                    {
                        Email = request.Email,
                        UserName = request.Email,
                        PhoneNumber = request.PhoneNumber,
                        Fullname = request.Fullname,
                        Avatar = request.Avatar,
                        WardId = request.Ward,
                        DistrictId = request.District,
                        ProvinceId = request.Province,
                        CountryId = request.Country,
                        Address = request.Address
                    };
                    var result = await userManager.CreateAsync(customer, request.Password);
                    if (result.Succeeded)
                    {
                        DynamicParameters parameters = new DynamicParameters();
                        parameters.Add("@UserId", customer.Id);
                        parameters.Add("@RoleId", "1");
                        var newCustomer = await SqlMapper.QueryFirstAsync<CustomerRegisterRes>(
                                                        cnn: connection,
                                                        sql: "sp_AddRoleToUser",
                                                        param: parameters,
                                                        commandType: CommandType.StoredProcedure);
                        return newCustomer;
                    }                    
                }
                return new CustomerRegisterRes();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

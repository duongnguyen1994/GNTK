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
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            this.customerRepository = customerRepository;
        }
        public async Task<CustomerRegisterRes> CreateCustomer(CustomerRegisterReq request)
        {
            try
            {
                var result = await customerRepository.CreateCustomer(request);
                if(!String.IsNullOrEmpty(result.Id))
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

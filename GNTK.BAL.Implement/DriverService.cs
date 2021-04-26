using GNTK.BAL.Interface;
using GNTK.DAL.Interface;
using GNTK.Domain.Requests;
using GNTK.Domain.Responses;
using System;
using System.Threading.Tasks;

namespace GNTK.BAL.Implement
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository driverRepository;

        public DriverService(IDriverRepository driverRepository)
        {
            this.driverRepository = driverRepository;
        }
        public async Task<DriverRegisterRes> CreateDriver(DriverRegisterReq request)
        {
            try
            {
                var result = await driverRepository.CreateDriver(request);
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

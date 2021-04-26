using GNTK.Domain.Requests;
using GNTK.Domain.Responses;
using System;
using System.Threading.Tasks;

namespace GNTK.BAL.Interface
{
    public interface IDriverService
    {
        public Task<DriverRegisterRes> CreateDriver(DriverRegisterReq request);
    }
}

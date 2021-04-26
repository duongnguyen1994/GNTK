using GNTK.Domain.Requests;
using GNTK.Domain.Responses;
using System;
using System.Threading.Tasks;

namespace GNTK.DAL.Interface
{
    public interface IDriverRepository
    {
        public Task<DriverRegisterRes> CreateDriver(DriverRegisterReq request);
    }
}

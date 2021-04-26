using GNTK.BAL.Interface;
using GNTK.Domain.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNTK.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IDriverService driverService;
        private readonly ICustomerService customerService;

        public AccountController(IDriverService driverService,
                                ICustomerService customerService)
        {
            this.driverService = driverService;
            this.customerService = customerService;
        }
        [HttpPost]
        [Route("CreateDriver")]
        public async Task<IActionResult> CreateDriver(DriverRegisterReq req)
        {
            return Ok(await driverService.CreateDriver(req));
        }
        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<IActionResult> CreateCustomer(CustomerRegisterReq req)
        {
            return Ok(await customerService.CreateCustomer(req));
        }
    }
}

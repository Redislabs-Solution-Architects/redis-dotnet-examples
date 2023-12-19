using Microsoft.AspNetCore.Mvc;
using Redis.DotNet.Examples.QueryParams.Models.Domain;
using Redis.DotNet.Examples.QueryParams.Models.Requests;
using Redis.DotNet.Examples.QueryParams.Models.Responses;
using Redis.DotNet.Examples.QueryParams.Services;

namespace Redis.DotNet.Examples.QueryParams.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService ?? throw new ArgumentNullException(nameof(customerService));
        }

        [HttpGet]
        public IActionResult Get([FromQuery] GetCustomerQuery parameters)
        {
            var results = _customerService
                .Search(parameters)
                .Skip((parameters.PageNumber - 1) * parameters.PageSize)
                .Take(parameters.PageSize);

            var pagedResponse = PagedResponse<Customer>
                 .Create(results, parameters.PageNumber, parameters.PageSize);

            return Ok(pagedResponse);
        }
    }
}


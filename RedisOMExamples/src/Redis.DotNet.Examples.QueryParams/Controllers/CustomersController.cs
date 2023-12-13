using Microsoft.AspNetCore.Mvc;
using Redis.DotNet.Examples.QueryParams.Models.Contracts;
using Redis.DotNet.Examples.QueryParams.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

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
        public IActionResult Get([FromQuery] CustomerQueryParameters parameters)
        {
            var results = _customerService.Search(parameters);

            return Ok(results.ToList());
        }
    }
}


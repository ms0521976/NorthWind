using Microsoft.AspNetCore.Mvc;
using NorthWind.Models.Domain;
using NorthWind.Data;
using AutoMapper;
using NorthWind.Models.Dto;

namespace NorthWindProject.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly NorthWindContext dbcontext;
        private readonly IMapper mapper;

        public CustomerController(NorthWindContext dbcontext,IMapper mapper)
        {
            this.dbcontext = dbcontext;
            this.mapper = mapper;
        }

        //get all Customer
        [HttpGet]
        public IActionResult GetAll()
        {
            var result = dbcontext.Customers.ToList();
            return Ok(result);
        }

        //get single Customer by ID
        [HttpGet]
        [Route("CustomerID")]
        public IActionResult GetCustomerByID([FromRoute] string customerID)
        {
            var result = dbcontext.Customers.Find(customerID);
            if (result == null)
                return NotFound();
            return Ok(result);
        }

        //update Customer by ID
        [HttpPost]
        [Route("CustomerID")]
        public async Task<IActionResult> CreateAsync([FromBody] string customerID)
        {
            var result = mapper.Map<List<CustomerDto>>(c)
        }
    }
}

﻿using Microsoft.AspNetCore.Mvc;
using NorthWind.Models.Domain;
using NorthWind.Data;
using AutoMapper;
using NorthWind.Models.Dto;
using NorthWind.Repositories;

namespace NorthWind.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly NorthWindContext dbcontext;
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRepository;

        public CustomerController(NorthWindContext dbcontext, IMapper mapper, ICustomerRepository customerRepository)
        {
            this.dbcontext = dbcontext;
            this.mapper = mapper;
            this.customerRepository = customerRepository;
        }

        //get all Customer
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var customerDomain = await customerRepository.GetAllAsync();
            var CustmoerDto = mapper.Map<List<CustomerDto>>(customerDomain);
            return Ok(CustmoerDto);
        }

        //get single Customer by ID
        [HttpGet]
        [Route("{customerID}")]
        public async Task<IActionResult> GetCustomerByIDAsync([FromRoute] string customerID)
        {
            var customerDomain = await customerRepository.GetCustomerByIDAsync(customerID);
            if (customerDomain == null)
                return NotFound();
            return Ok(mapper.Map<CustomerDto>(customerDomain));
        }

        //update Customer by ID
        [HttpPost]
        [Route("CustomerID")]
        public async Task<IActionResult> CreateAsync([FromBody] CustomerDto customerDto)
        {
            var customerDomain = mapper.Map<Customer>(customerDto);
            customerDomain = await customerRepository.CreateAsync(customerDomain);
            return CreatedAtAction(nameof(GetCustomerByIDAsync), new { id = customerDto.CustomerId }, customerDto);

        }
    }
}

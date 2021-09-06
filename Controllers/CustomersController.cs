using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieRentalsAPI.Controllers.Dtos;
using MovieRentalsAPI.Core;
using MovieRentalsAPI.Core.Models;

namespace MovieRentalsAPI.Controllers
{
    [Route("/api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repository;
        private readonly IMapper _mapper;
        public CustomersController(ICustomerRepository repository, IMapper mapper)
        {
            this._mapper = mapper;
            this._repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            var customers = await _repository.GetAll();
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);
        }

        [HttpGet("{id}")]
        public async Task<CustomerDto> Get(int id)
        {
            var customer = await _repository.Get(id);
            return _mapper.Map<Customer, CustomerDto>(customer);
        }
    }
}
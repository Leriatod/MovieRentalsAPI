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
        private readonly IUnitOfWork _unitOfWork;
        public CustomersController(ICustomerRepository repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _repository = repository;
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

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var customer = await _repository.Get(id);
            if (customer == null) return BadRequest();

            _repository.Delete(customer);
            await _unitOfWork.CompleteAsync();

            return Ok();
        }
    }
}
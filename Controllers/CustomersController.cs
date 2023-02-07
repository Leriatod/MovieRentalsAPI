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
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _repository.Get(id);

            if (customer == null)
                return NotFound("Customer not found!");

            return Ok(_mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var customer = await _repository.Get(id);

            if (customer == null)
                return NotFound("Customer not found!");

            _repository.Delete(customer);

            await _unitOfWork.Complete();

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = _mapper.Map<CustomerDto, Customer>(customerDto);

            _repository.Add(customer);

            await _unitOfWork.Complete();

            customer = await _repository.Get(customer.Id);

            return Ok(_mapper.Map<Customer, CustomerDto>(customer));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var customer = await _repository.Get(id);

            if (customer == null)
                return NotFound("Customer not found!");

            _mapper.Map(customerDto, customer);
            customer.Id = id;

            await _unitOfWork.Complete();

            customer = await _repository.Get(customer.Id);

            return Ok(_mapper.Map<Customer, CustomerDto>(customer));
        }
    }
}
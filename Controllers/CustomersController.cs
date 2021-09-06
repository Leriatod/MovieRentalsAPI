using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MovieRentalsAPI.Controllers.Dtos;
using MovieRentalsAPI.Core.Models;
using MovieRentalsAPI.Persistence;

namespace MovieRentalsAPI.Controllers
{
    [Route("/api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly MovieRentalsDbContext _context;
        private readonly IMapper _mapper;
        public CustomersController(MovieRentalsDbContext context, IMapper mapper)
        {
            this._mapper = mapper;
            this._context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<CustomerDto>> GetAll()
        {
            var customers = await _context.Customers.ToListAsync();
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerDto>>(customers);
        }
    }
}
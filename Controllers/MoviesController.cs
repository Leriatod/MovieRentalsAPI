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
    [Route("/api/movies")]
    public class MoviesController
    {
        private readonly MovieRentalsDbContext _context;
        private readonly IMapper _mapper;
        public MoviesController(MovieRentalsDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieDto>> GetAll()
        {
            var movies = await _context.Movies.ToListAsync();
            return _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDto>>(movies);
        }
    }
}
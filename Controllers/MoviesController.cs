using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MovieRentalsAPI.Controllers.Dtos;
using MovieRentalsAPI.Core;
using MovieRentalsAPI.Core.Models;

namespace MovieRentalsAPI.Controllers
{
    [Route("/api/movies")]
    public class MoviesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMovieRepository _repository;

        public MoviesController(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<MovieDto>> GetAll()
        {
            var movies = await _repository.GetAll();
            return _mapper.Map<IEnumerable<Movie>, IEnumerable<MovieDto>>(movies);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var movie = await _repository.Get(id);

            if (movie == null)
                return NotFound("Movie not found!");

            return Ok(_mapper.Map<Movie, MovieDto>(movie));
        }
    }
}
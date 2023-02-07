using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRentalsAPI.Controllers.Dtos;
using MovieRentalsAPI.Core;
using MovieRentalsAPI.Core.Models;

namespace MovieRentalsAPI.Controllers
{
    [Route("/api/rentals")]
    public class RentalsController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IRentalRepository _rentalRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RentalsController(ICustomerRepository customerRepository,
                                 IMovieRepository movieRepository,
                                 IRentalRepository rentalRepository,
                                 IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _movieRepository = movieRepository;
            _rentalRepository = rentalRepository;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> RentMoviesForCustomer([FromBody] CustomerRentedMoviesDto customerRentedMoviesDto)
        {
            var customer = await _customerRepository.Get(customerRentedMoviesDto.CustomerId);

            if (customer == null)
                return NotFound("Customer not found.");

            foreach (var movieId in customerRentedMoviesDto.MovieIds)
            {
                var movie = await _movieRepository.Get(movieId);

                if (movie == null)
                    return NotFound("Movie not found.");

                if (movie.NumberInStock == 0)
                    return BadRequest("Movie is not available");

                movie.NumberInStock--;

                _rentalRepository.Add(new Rental()
                {
                    RentDate = DateTime.Now,
                    ReturnDate = customerRentedMoviesDto.ReturnDate,
                    CustomerId = customerRentedMoviesDto.CustomerId,
                    MovieId = movieId,
                });
            }

            await _unitOfWork.Complete();

            return Ok();
        }
    }
}
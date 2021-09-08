using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRentalsAPI.Controllers.Dtos;
using MovieRentalsAPI.Core.Models;
using MovieRentalsAPI.Persistence;

namespace MovieRentalsAPI.Controllers
{
    [Route("/api/rentals")]
    public class RentalsController : ControllerBase
    {
        private readonly MovieRentalsDbContext _context;
        public RentalsController(MovieRentalsDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> RentMoviesForCustomer([FromBody] CustomerRentedMoviesDto customerRentedMoviesDto)
        {
            var customer = await _context.Customers.FindAsync(customerRentedMoviesDto.CustomerId);

            if (customer == null)
                return NotFound("Customer not found.");

            foreach (var movieId in customerRentedMoviesDto.MovieIds)
            {
                var movie = await _context.Movies.FindAsync(movieId);

                if (movie == null)
                    return NotFound("Movie not found.");

                if (movie.NumberInStock == 0)
                    return BadRequest("Movie is not available");

                movie.NumberInStock--;

                _context.Rentals.Add(new Rental()
                {
                    RentDate = DateTime.Now,
                    ReturnDate = customerRentedMoviesDto.ReturnDate,
                    CustomerId = customerRentedMoviesDto.CustomerId,
                    MovieId = movieId,
                });
            }
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
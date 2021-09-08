using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalsAPI.Controllers.Dtos
{
    public class CustomerRentedMoviesDto
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public ICollection<int> MovieIds { get; set; }
        [Required]
        public DateTime ReturnDate { get; set; }
        public CustomerRentedMoviesDto()
        {
            MovieIds = new Collection<int>();
        }
    }
}
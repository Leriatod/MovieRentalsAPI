using System;

namespace MovieRentalsAPI.Controllers.Dtos
{
    public class RentalDto
    {
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public MovieDto Movie { get; set; }
        public int MovieId { get; set; }
    }
}
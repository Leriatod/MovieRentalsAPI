using System;
namespace MovieRentalsAPI.Core.Models
{
    public class Rental
    {
        public int Id { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public Customer Customer { get; set; }
        public Movie Movie { get; set; }
        public int CustomerId { get; set; }
        public int MovieId { get; set; }
    }
}
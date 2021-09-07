using System.ComponentModel.DataAnnotations;

namespace MovieRentalsAPI.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public int NumberInStock { get; set; }
        public decimal DailyRentalRate { get; set; }
        [Required]
        [StringLength(255)]
        public string BarCode { get; set; }
    }
}
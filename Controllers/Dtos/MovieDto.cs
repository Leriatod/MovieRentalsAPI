using System.ComponentModel.DataAnnotations;

namespace MovieRentalsAPI.Controllers.Dtos
{
    public class MovieDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public int NumberInStock { get; set; }
        public decimal DailyRentalRate { get; set; }
        [Required]
        [StringLength(255)]
        public string BarCode { get; set; }
    }
}
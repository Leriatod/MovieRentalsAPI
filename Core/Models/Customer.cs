using System.ComponentModel.DataAnnotations;

namespace MovieRentalsAPI.Core.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        [Required]
        [StringLength(255)]
        public string Email { get; set; }
        [Required]
        [StringLength(255)]
        public string PhoneNumber { get; set; }
    }
}
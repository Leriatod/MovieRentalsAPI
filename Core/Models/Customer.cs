using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ICollection<Rental> Rentals { get; set; }

        public Customer()
        {
            Rentals = new Collection<Rental>();
        }
    }
}
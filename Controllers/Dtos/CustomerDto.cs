using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieRentalsAPI.Controllers.Dtos
{
    public class CustomerDto
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

        public ICollection<RentalDto> Rentals { get; set; }

        public CustomerDto()
        {
            Rentals = new Collection<RentalDto>();
        }
    }
}
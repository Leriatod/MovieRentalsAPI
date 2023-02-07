using AutoMapper;
using MovieRentalsAPI.Controllers.Dtos;
using MovieRentalsAPI.Core.Models;

namespace MovieRentalsAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateDomainToDtosMappings();
            CreateDtosToDomainMappings();
        }

        private void CreateDtosToDomainMappings()
        {
            CreateMap<CustomerDto, Customer>()
                .ForMember(x => x.Rentals, opt => opt.Ignore());
        }

        private void CreateDomainToDtosMappings()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<Rental, RentalDto>();
        }
    }
}
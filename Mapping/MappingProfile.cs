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
        }

        private void CreateDomainToDtosMappings()
        {
            CreateMap<Customer, CustomerDto>();
        }
    }
}
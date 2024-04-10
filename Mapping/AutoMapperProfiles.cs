using AutoMapper;
using NorthWind.Models.Domain;
using NorthWind.Models.Dto;

namespace NorthWindProject.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();
            CreateMap<UpdateCustomerDto, Customer>().ReverseMap();
        }
    }
}

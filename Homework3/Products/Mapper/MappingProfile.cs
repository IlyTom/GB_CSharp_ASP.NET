using AutoMapper;
using Products.Models;
using Products.Models.DTO;

namespace Products.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<ProductDTO, Product>()
                .ForMember(d => d.Id, o => o.Ignore())
                .ForMember(d => d.Name, o => o.MapFrom(y => y.Name))
                .ForMember(d => d.Description, o => o.MapFrom(y => y.Description))
                .ForMember(d => d.Price, o => o.MapFrom(y => y.Price)).ReverseMap();
        }
    }
}

using AutoMapper;
using ProductStore.Models;
using ProductStore.Models.DTO;

namespace ProductStore.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() { 
            CreateMap<StoreItemDTO, StoreItem>().ReverseMap();
        }
    }
}

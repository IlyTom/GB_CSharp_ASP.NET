using AutoMapper;
using Store.Models;
using Store.Models.DTO;

namespace Store.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<StoreDTO, Models.Store>().ReverseMap();
        }
    }
}

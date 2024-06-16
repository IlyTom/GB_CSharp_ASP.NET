using Application.Models;
using Application.Models.DTO;
using AutoMapper;

namespace Application.Repo
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<Product, ProductDto>(MemberList.Destination).ReverseMap();
            CreateMap<ProductGroup, GroupDto>(MemberList.Destination).ReverseMap();
            CreateMap<Store, StoreDto>(MemberList.Destination).ReverseMap();    
        }

    }
}

using AutoMapper;
using Entities.Dtos;
using Entities.Models;

namespace StoreApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile

    {
        public MappingProfile()
        {

            //ProductDto bizim kaynağımız, sen bize product vericeksin xd
            CreateMap<ProductDtoForInsertion, Product>();

            //resource first => destination
            CreateMap<ProductDtoForUpdate, Product>().ReverseMap();

            //bilgi updateden geliyor biz Product'a çeviriyoruz.
        }
    }
}
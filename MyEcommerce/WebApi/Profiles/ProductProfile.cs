using AutoMapper;
using Domain.Products;
using WebApi.DTOs;

namespace WebApi.Profiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductDto>()
                .ReverseMap();
        }
    }
}

using AutoMapper;
using Domain.Products;
using WebApi.DTOs;

namespace WebApi.Profiles
{
    public class ShoppingCartsProductsProfile : Profile
    {
        public ShoppingCartsProductsProfile()
        {
            CreateMap<ShoppingCartsProducts, ShoppingCartsProductsDto>()
                .ReverseMap();
        }
    }
}

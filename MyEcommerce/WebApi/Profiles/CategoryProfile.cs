using AutoMapper;
using Domain.Products;
using WebApi.DTOs;

namespace WebApi.Profiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryDto>();
        }

    }
}

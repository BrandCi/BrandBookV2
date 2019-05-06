using AutoMapper;
using BrandBook.Core.Domain.Brand;
using BrandBook.Core.Dtos.Brand;

namespace BrandBook.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<BrandDto, Brand>();
        }
    }
}
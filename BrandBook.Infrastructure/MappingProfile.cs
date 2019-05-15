using AutoMapper;
using BrandBook.Core.Domain.Brand;
using BrandBook.Core.Domain.User;
using BrandBook.Core.Dtos.Brand;
using BrandBook.Core.Dtos.User;

namespace BrandBook.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<BrandDto, Brand>();

            CreateMap<AppUserDto, AppUser>();
            CreateMap<AppUser, AppUserDto>();
        }
    }
}
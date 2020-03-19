using AutoMapper;

using BrandBook.Core.Domain.Frontend;
using BrandBook.Core.Dto.Frontend.Blog;


namespace BrandBook.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // App


            // Auth


            // Frontend
            CreateMap<BlogEntry, BlogOverviewDto>();
            CreateMap<BlogEntry, BlogDetailDto>();


        }
    }
}
using AutoMapper;

using BrandCi.Core.Domain.Frontend;
using BrandCi.Core.Dto.Frontend.Blog;


namespace BrandCi.Infrastructure.Mapping
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
using AutoMapper;

using BrandBook.Core.Domain.Frontend;
using BrandBook.Core.Dto.Frontend.Blog;


namespace BrandBook.Infrastructure.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<BlogEntry, BlogOverviewDto>();


        }
    }
}
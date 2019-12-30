using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;

using BrandBook.Core;
using BrandBook.Infrastructure;
using BrandBook.Core.Domain.Frontend;
using BrandBook.Core.Dto.Frontend.Blog;
using System.Threading.Tasks;

namespace BrandBook.Web.Api.Frontend
{
    [RoutePrefix("api/blogs")]
    public class BlogsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [Route("")]
        public async Task<IEnumerable<BlogOverviewDto>> GetAll()
        {
            var allBlogs = await _unitOfWork.BlogEntryRepository.GetAllPublishedBlogEntriesForAnonymousUserAsync(); ;

            if(User.Identity.IsAuthenticated)
            {
                allBlogs = await _unitOfWork.BlogEntryRepository.GetAllPublishedBlogEntriesAsync();
            }


            return Mapper.Map<IEnumerable<BlogEntry>, IEnumerable<BlogOverviewDto>>(allBlogs);

        }


        [Route("{blogKey}")]
        public IHttpActionResult GetBlog(string blogKey)
        {
            if (blogKey == "" || !_unitOfWork.BlogEntryRepository.BlogEntryKeyExists(blogKey))
            {
                return BadRequest();
            }

            var blog = _unitOfWork.BlogEntryRepository.FindBlogEntryByKey(blogKey);


            return Ok(Mapper.Map<BlogEntry, BlogDetailDto>(blog));

        }
        

    }
}

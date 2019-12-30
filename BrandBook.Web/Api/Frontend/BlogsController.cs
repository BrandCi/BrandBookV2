using System.Collections.Generic;
using System.Web.Http;
using AutoMapper;
using System.Threading.Tasks;

using BrandBook.Core;
using BrandBook.Core.Domain.Frontend;
using BrandBook.Core.Dto.Frontend.Blog;


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
            var allBlogs = await _unitOfWork.BlogEntryRepository.GetAllPublishedBlogEntriesForAnonymousUserAsync();

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
﻿using System.Collections.Generic;
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
    public class BlogsController : ApiController
    {
        private readonly IUnitOfWork _unitOfWork;

        public BlogsController()
        {
            _unitOfWork = new UnitOfWork();
        }


        
        public async Task<IEnumerable<BlogDto>> GetAll()
        {
            var allBlogs = await _unitOfWork.BlogEntryRepository.GetAllPublishedBlogEntriesForAnonymousUserAsync(); ;

            if(User.Identity.IsAuthenticated)
            {
                allBlogs = await _unitOfWork.BlogEntryRepository.GetAllPublishedBlogEntriesAsync();
            }


            return Mapper.Map<IEnumerable<BlogEntry>, IEnumerable<BlogDto>>(allBlogs);

        }
        


    }
}

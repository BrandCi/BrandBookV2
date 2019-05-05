using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using AutoMapper;
using BrandBook.Core.Domain.Brand;
using BrandBook.Core.Dtos.Brand;
using BrandBook.Core.RepositoryInterfaces.Brand;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Brand;

namespace BrandBook.Web.Api
{
    [Authorize]
    public class BrandController : ApiController
    {

        private IBrandRepository brandRepository;

        public BrandController()
        {
            this.brandRepository = new BrandRepository(new BrandBookDbContext());
        }



        public IHttpActionResult GetBrands()
        {
            var allBrands = brandRepository.GetAll().Select(Mapper.Map<Brand, BrandDto>);

            return Ok(allBrands);
        }

        public IHttpActionResult GetBrand(int id)
        {
            var brand = brandRepository.FindById(id);

            return Ok(brand);
        }


        [HttpPost]
        public IHttpActionResult CreateBrand(BrandDto brandDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var brand = Mapper.Map<BrandDto, Brand>(brandDto);
            brandRepository.Add(brand);

            return Created(new Uri(Request.RequestUri + "/" + brand.Id), brandDto);
        }

    }
}

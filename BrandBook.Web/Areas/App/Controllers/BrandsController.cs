using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BrandBook.Core.RepositoryInterfaces.Brand;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Brand;
using BrandBook.Web.Framework.Controllers;

namespace BrandBook.Web.Areas.App.Controllers
{
    public class BrandsController : AppControllerBase
    {
        private IBrandRepository brandRepository;

        public BrandsController()
        {
            this.brandRepository = new BrandRepository(new BrandBookDbContext());
        }




        // GET: App/Brands
        public ActionResult Overview()
        {
            return View();
        }
    }
}   
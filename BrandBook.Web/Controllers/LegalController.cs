using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using BrandBook.Core.RepositoryInterfaces.Frontend.Legal;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Frontend.Legal;
using BrandBook.Web.ViewModels.Legal;

namespace BrandBook.Web.Controllers
{
    public class LegalController : Controller
    {

        #region Fields

        private IImprintValueRepository imprintValueRepository;

        #endregion

        #region Constructor

        public LegalController()
        {
            this.imprintValueRepository = new ImprintValueRepository(new BrandBookDbContext());
        }

        #endregion



        // GET: Legal
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Imprint()
        {
            ImprintViewModel model = new ImprintViewModel()
            {
                ImprintValues = imprintValueRepository.GetImprintValues()
            };
            return View();
        }

        public ActionResult PrivacyPolicy()
        {
            return View();
        }
    }
}
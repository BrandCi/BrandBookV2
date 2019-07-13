using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Resources;

namespace BrandBook.Web.Framework.ViewModels.App.Profile
{
    public class GeneralUserDataViewModel
    {
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Web.Framework.ViewModels.App.Brand
{
    public class AddNewBrandViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Required]
        public string MainColor { get; set; }

        public int ImageId { get; set; }

        [Display(Name = "Agree Terms and Conditions")]
        [Range(typeof(bool), "true", "true", ErrorMessage = "Please agree Terms and Conditions")]
        public bool AgreeTerms { get; set; }



    }
}

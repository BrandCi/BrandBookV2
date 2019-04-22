using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BrandBook.Web.ViewModels.Authorization
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Nutzername")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Passwort")]
        public string Password { get; set; }
    }
}
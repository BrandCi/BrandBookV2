﻿using BrandBook.Resources;
using System.ComponentModel.DataAnnotations;

namespace BrandBook.Core.ViewModels.Auth
{
    public class RegisterViewModel
    {

        [Required]
        [EmailAddress]
        [Display(Name = "auth_register_input_email", ResourceType = typeof(Translations))]
        public string Email { get; set; }


        [Required]
        [Display(Name = "auth_register_input_username", ResourceType = typeof(Translations))]
        public string Username { get; set; }


        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "auth_register_input_password", ResourceType = typeof(Translations))]
        public string Password { get; set; }


        [DataType(DataType.Password)]
        [Display(Name = "auth_register_input_confirmpassword", ResourceType = typeof(Translations))]
        [Compare("Password", ErrorMessage = "Die Passwörter stimmen nicht überein")]
        public string ConfirmPassword { get; set; }


        [Range(typeof(bool), "true", "true", ErrorMessageResourceName = "auth_register_checkbox_privacypolicy_validation", ErrorMessageResourceType = typeof(Translations))]
        [Display(Name = "auth_register_checkbox_privacypolicy_title", ResourceType = typeof(Translations))]
        public bool PrivacyPolicyAccepted { get; set; }

        [Required]
        [Display(Name = "Beta Accesscode")]
        public string PromotionCode { get; set; }

        public string ReCaptchaToken { get; set; }

    }
}

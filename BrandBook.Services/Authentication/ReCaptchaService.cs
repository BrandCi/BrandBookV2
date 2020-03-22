﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using BrandBook.Core.Services.Authentication;
using BrandBook.Core.ViewModels;
using Newtonsoft.Json;

namespace BrandBook.Services.Authentication
{
    public class ReCaptchaService : IReCaptchaService
    {
        public async Task<bool> IsCaptchaValid(string response, string userHostAddress, string captchaAction)
        {
            try
            {
                var secret = ConfigurationManager.AppSettings["ReCaptchaSecretKey"];

                using (var client = new HttpClient())
                {
                    var values = new Dictionary<string, string>
                    {
                        {"secret", secret},
                        {"response", response},
                        {"remoteip", userHostAddress}
                    };

                    var content = new FormUrlEncodedContent(values);
                    var verify = await client.PostAsync("https://www.google.com/recaptcha/api/siteverify", content);
                    var captchaResponseJson = await verify.Content.ReadAsStringAsync();

                    var captchaResult = JsonConvert.DeserializeObject<ReCaptchaResponseViewModel>(captchaResponseJson);

                    return captchaResult.Success && captchaResult.Action == captchaAction && captchaResult.Score > 0.5;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        public async Task<bool> IsCaptchaActiveAndValid(string response, string userHostAddress, string captchaAction)
        {
            var isCaptchaValid = await IsCaptchaValid(response, userHostAddress, captchaAction);

            return IsCaptchaActive() && isCaptchaValid;
        }

        public bool IsCaptchaActive()
        {
            return ConfigurationManager.AppSettings["ReCaptchaActive"] == "1";
        }
    }
}

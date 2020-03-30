using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BrandBook.Core.Services.Authentication
{
    public interface IReCaptchaService
    {
        Task<bool> IsCaptchaValid(string response, string userHostAddress, string captchaAction);
        Task<bool> IsCaptchaActiveAndValid(string response, string userHostAddress, string captchaAction);
        bool IsCaptchaActive();
    }
}

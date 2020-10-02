using System.Threading.Tasks;

namespace BrandCi.Core.Services.Authentication
{
    public interface IReCaptchaService
    {
        Task<bool> IsCaptchaValid(string response, string userHostAddress, string captchaAction);
        Task<bool> IsCaptchaActiveAndValid(string response, string userHostAddress, string captchaAction);
        bool IsCaptchaActive();
    }
}

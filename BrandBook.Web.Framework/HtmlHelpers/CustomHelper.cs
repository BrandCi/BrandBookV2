using BrandBook.Core.Repositories.Setting;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Setting;
using System.Configuration;
using System.Text;
using System.Web;

namespace BrandBook.Web.Framework.HtmlHelpers
{
    public static class CustomHelper
    {

        private static readonly ISettingRepository settingRepository;

        static CustomHelper()
        {
            settingRepository = new SettingRepository(new BrandBookDbContext());
        }

        public static string ImagePath(string imageName, string imageType, string imageSection = "")
        {
            var contentServer = settingRepository.GetSettingByKey("conf_media_server").Value;
            var contentKey = settingRepository.GetSettingByKey("conf_media_key").Value;

            if (imageType != "")
            {
                imageName = imageName + "." + imageType;
            }

            if (imageSection != "")
            {
                return "https://" + contentServer + "/" + contentKey + "/" + imageSection + "/" + imageName;
            }
            return "https://" + contentServer + "/" + contentKey + "/" + imageName;
        }

        public static IHtmlString Image(string imageName, string imageType, string classes = "", string styles = "", string additionalAttributes = "")
        {

            var html = new StringBuilder();

            html.Append("<img");

            html.Append(" src=\"");
            html.Append(ImagePath(imageName, imageType));
            html.Append("\" ");

            if (classes != "")
            {
                html.Append(" class=\"" + classes + "\" ");
            }

            if (styles != "")
            {
                html.Append(" style=\"" + styles + "\" ");
            }

            if (additionalAttributes != "")
            {
                html.Append(" " + additionalAttributes + " ");
            }



            html.Append(" />");

            return new HtmlString(html.ToString());
        }

        public static IHtmlString SharedStorageImage(string imageNameAndType, string classes = "", string styles = "", string additionalAttributes = "")
        {


            var html = new StringBuilder();

            html.Append("<img");

            html.Append(" src=\"");
            html.Append(imageNameAndType);
            html.Append("\" ");

            if (classes != "")
            {
                html.Append(" class=\"" + classes + "\" ");
            }

            if (styles != "")
            {
                html.Append(" style=\"" + styles + "\" ");
            }

            if (additionalAttributes != "")
            {
                html.Append(" " + additionalAttributes + " ");
            }



            html.Append(" />");

            return new HtmlString(html.ToString());
        }

        public static IHtmlString RenderReCaptchaRequest(string action)
        {
            var html = new StringBuilder();

            if (!IsReCaptchaActive())
            {
                return new HtmlString(html.ToString());
            }

            var recaptchaSiteKey = ConfigurationManager.AppSettings["ReCaptchaSiteKey"];

            html.Append("<script src=\"https://www.google.com/recaptcha/api.js?render=" + recaptchaSiteKey + "\"></script>");
            html.Append("<script>");

            html.Append("grecaptcha.ready(function() {");
            html.Append("grecaptcha.execute('" + recaptchaSiteKey + "', { action: '" + action + "' }).then(function (token) {");
            html.Append("$('#ReCaptchaToken').val(token);");
            html.Append("});");
            html.Append("});");

            html.Append("</script>");

            return new HtmlString(html.ToString());
        }

        public static bool IsReCaptchaActive()
        {
            bool.TryParse(ConfigurationManager.AppSettings["ReCaptchaActive"], out var reCaptchaActive);
            return reCaptchaActive;
        }
    }

}
using BrandBook.Core.Repositories.Setting;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Setting;
using System.Configuration;
using System.Text;
using System.Web;
using BrandBook.Web.Framework.Helpers;

namespace BrandBook.Web.Framework.HtmlHelpers
{
    public static class CustomHtmlHelper
    {

        private static readonly ISettingRepository settingRepository;

        static CustomHtmlHelper()
        {
            settingRepository = new SettingRepository(new BrandBookDbContext());
        }


        public static IHtmlString Image(string imageFileName, string classes = "", string styles = "", string additionalAttributes = "")
        {

            var html = new StringBuilder();

            html.Append("<img");

            html.Append(" src=\"");
            html.Append(CustomHelper.GetImagePath(imageFileName));
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

            if (!CustomHelper.IsReCaptchaActive())
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
    }

}
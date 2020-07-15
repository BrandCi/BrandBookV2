using System.Text;
using System.Web;

namespace BrandBook.Web.Framework.HtmlHelpers
{
    public static class AuthCustomHelper
    {
        public static IHtmlString RenderBackground(string imageName = "", string imageType = "")
        {
            var html = new StringBuilder();

            html.Append("<div class=\"img-holder\">");
            html.Append("<div class=\"bg\"></div>");

            if (imageName != "" && imageType != "")
            {
                html.Append("<div class=\"info-holder\">");
                html.Append("<img src=\"");
                html.Append(CustomHtmlHelper.ImagePath(imageName, imageType, "AuthData"));
                html.Append("\" />");
                html.Append("</div>");
            }

            html.Append("</div>");


            return new HtmlString(html.ToString());
        }


    }
}
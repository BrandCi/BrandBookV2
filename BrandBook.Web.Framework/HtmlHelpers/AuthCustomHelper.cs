using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BrandBook.Web.Framework.HtmlHelpers
{
    public static class AuthCustomHelper
    {

        public static IHtmlString RenderBackground(string backgroundSrc = "")
        {
            StringBuilder html = new StringBuilder();

            html.Append("<div class=\"img-holder\">");
                html.Append("<div class=\"bg\"></div>");

                if (backgroundSrc != "")
                {
                    html.Append("<div class=\"info-holder\">");
                        html.Append("<img src=\"");
                        html.Append(backgroundSrc);
                        html.Append("\" />");
                    html.Append("</div>");
                }

            html.Append("</div>");


            return new HtmlString(html.ToString());
        }


    }
}
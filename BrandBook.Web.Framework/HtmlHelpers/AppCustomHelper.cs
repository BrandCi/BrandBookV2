using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebPages;

namespace BrandBook.Web.Framework.HtmlHelpers
{
    public static class AppCustomHelper
    {

        public static IHtmlString GetPageTitle(bool showPageTitle = true, string pageTitle = "", string parentTitle = "", string rootParentTitle = "")
        {
            if (!showPageTitle)
            {
                return new HtmlString("");
            }


            StringBuilder html = new StringBuilder();

            html.Append("<div class=\"row\"><div class=\"col-sm-12\"><div class=\"page-title-box\">");

            html.Append("<h4 class=\"page-title\">Dashboard</h4>");

            html.Append("<ol class=\"breadcrumb float-right hide-phone\">");

            if (rootParentTitle != "")
            {
                html.Append("<li class=\"breadcrumb-item\"><a href = \"#\">" + rootParentTitle + "</a></li>");
            }

            if (parentTitle != "")
            {
                html.Append("<li class=\"breadcrumb-item\"><a href=\"#\">" + parentTitle + "</a></li>");
            }

            html.Append("<li class=\"breadcrumb-item active\">" + pageTitle + "</li>");

            html.Append("</ol>");

            html.Append("<div class=\"clearfix\"></div>");

            html.Append("</div></div></div>");


            return new HtmlString(html.ToString());
            
        }


    }
}
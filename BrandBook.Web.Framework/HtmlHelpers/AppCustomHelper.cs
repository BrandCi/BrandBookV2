using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebPages;
using BrandBook.Web.Framework.ViewModels.App.Brand;

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


        public static IHtmlString BrandOverviewItem(BrandOverviewViewModel model)
        {
            string contentSrv = "https://content.philipp-moser.de/wlo0t5byw6";
            StringBuilder html = new StringBuilder();

            foreach (var item in model)
            {
                html.Append("<div class=\"col-sm-6 col-lg-4 col-xs-12\">");
                html.Append("<div class=\"card m-b-20\">");

                html.Append("<img class=\"card-img-top img-fluid\" src=\"" + contentSrv + item + "\" alt=\"Card image cap\">");
                html.Append("<div class=\"card-body\">");
                html.Append("<h2 class=\"card-title\">" + item + "</h2>");
                html.Append("<p class=\"card-text\">");
                html.Append(item);
                html.Append("</p>");

                html.Append("<a href=\"" + item + "\" class=\"btn btn-primary\" style=\"background-color: #" + item + "; border: none;\">");
                html.Append("Marke öffnen");
                html.Append("</a>");
                html.Append("</div></div></div>");

            }

            return new HtmlString(html.ToString());
        }

    }

}
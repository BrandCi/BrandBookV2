using BrandBook.Resources;
using BrandBook.Core.ViewModels.App.Brand;
using System.Text;
using System.Web;

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


            var html = new StringBuilder();

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


        public static IHtmlString BrandOverviewItem(BrandsOverviewViewModel model)
        {
            var html = new StringBuilder();

            foreach (var brand in model)
            {
                var linkTargetImage = model.HasValidSubscription;

                if (brand.MainHexColor == null || brand.MainHexColor == "ffffff")
                {
                    brand.MainHexColor = "193357";
                }

                html.Append("<div class=\"col-sm-6 col-lg-4 col-xs-12\">");
                html.Append("<div class=\"card m-b-20\">");

                if(linkTargetImage)
                {
                    html.Append("<a href=\"" + "/App/Brand/Index/" + brand.Id + "\">");

                }
                html.Append("<img class=\"card-img-top img-fluid\" src=\"/SharedStorage/BrandImages/" + brand.BrandImage.Name + "\" alt=\"" + brand.Name + "\" />");

                if(linkTargetImage)
                {
                    html.Append("</a>");
                }
                

                html.Append("<div class=\"card-body\">");

                html.Append("<h2 class=\"card-title\">" + brand.Name + "</h2>");
                html.Append("<p class=\"card-text\">");
                html.Append(brand.ShortDescription);
                html.Append("</p>");


                if (model.HasValidSubscription)
                {
                    html.Append("<a ");
                    html.Append("href=\"" + "/App/Brand/Index/" + brand.Id + "\" class=\"btn btn-primary\" ");
                    html.Append("style =\"background-color: #" + brand.MainHexColor + "; border: none;\">");


                    html.Append(Translations.app_brandoverview_openbrand_button_title);
                    html.Append("</a>");
                }
                else
                {
                    html.Append("<div class=\"alert alert-warning alert-dismissible bg-light border-warning text-warning fade show\" role=\"alert\" style=\"background-color: transparent !important;\">");
                    html.Append("Update your subscription to continue working on your brand");
                    html.Append("</div>");
                }
                

                

                html.Append("</div>");
                html.Append("</div>");
                html.Append("</div>");

            }

            return new HtmlString(html.ToString());
        }


        public static IHtmlString VersionInfoItem(bool leftItem, string versionNumber, string releaseDate, string description)
        {
            var html = new StringBuilder();

            if (leftItem)
            {
                html.Append("<article class=\"timeline-item alt\">");
            }
            else
            {
                html.Append("<article class=\"timeline-item\">");
            }

            html.Append("<div class=\"timeline-desk\">");
            html.Append("<div class=\"panel\">");
            html.Append("<div class=\"panel-body\">");
            html.Append("<span class=\"arrow-alt\"></span>");
            html.Append("<span class=\"timeline-icon\"></span>");

            html.Append("<h4 class=\"text-danger\">" + versionNumber + "</h4>");
            html.Append("<p class=\"timeline-date text-muted\"><small>" + releaseDate + "</small></p>");

            html.Append("<p>");
            html.Append(description);
            html.Append("</p>");

            html.Append("</div></div></div></article>");


            return new HtmlString(html.ToString());
        }

    }

}
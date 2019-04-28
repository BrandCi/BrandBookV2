using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BrandBook.Web.Framework.HtmlHelpers
{
    public static class FrontendCustomHelper
    {


        public static IHtmlString PricingItem(string title, string image, double pricePerMonth, bool termBasedPayment, List<string> featureList, string buttonTitle)
        {
            StringBuilder html = new StringBuilder();

            html.Append("<!--LMT--><div class=\"card mb-4\">");

            html.Append("<div class=\"card-header\">");
            html.Append("<img src=\"" + image + "\" />");
            html.Append("<h4 class=\"mt-3 mb-3 font-weight-normal\">" + title + "</h4>");
            html.Append("</div>");

            html.Append("<div class=\"card-body\">");

            if (termBasedPayment)
            {
                html.Append("<h1 class=\"card-title pricing-title\">€" + pricePerMonth + "<small class=\"text-muted\">/ Monat</small></h1>");
            }
            else
            {
                html.Append("<h1 class=\"card-title pricing-title\">Nutzungsbasiert</h1>");
            }

            if (featureList.Count != 0)
            {
                html.Append("<ul class=\"list-unstyled mt-3 mb-4 pricing-description\">");

                foreach (string item in featureList)
                {
                    html.Append("<li>");
                    html.Append(item);
                    html.Append("</li>");
                }

                html.Append("</ul>");
            }

            html.Append("<a class=\"btn btn-lg btn-block btn-primary btn-pricing\">");
            html.Append(buttonTitle);
            html.Append("</a>");
            html.Append("</div>");
            html.Append("</div><!--LMT-->");



            return new HtmlString(html.ToString());

        }
        
    }
}
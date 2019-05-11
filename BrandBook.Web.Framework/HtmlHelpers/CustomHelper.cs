using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using BrandBook.Core.RepositoryInterfaces.Setting;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Setting;

namespace BrandBook.Web.Framework.HtmlHelpers
{
    public static class CustomHelper
    {

        private static ISettingRepository settingRepository;
        private static string contentServer = settingRepository.GetSettingByKey("conf_media_server").Value;
        private static string contentKey = settingRepository.GetSettingByKey("conf_media_key").Value;

        static CustomHelper()
        {
            settingRepository = new SettingRepository(new BrandBookDbContext());
        }


        public static IHtmlString Image(string imageName, string imageType, string classes = "", string styles = "", string additionalAttributes = "")
        {

            StringBuilder html = new StringBuilder();

            html.Append("<img");

            html.Append(" src=\"");
            html.Append("https://" + contentServer + "/" + contentKey + "/" + imageName + "." + imageType);
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

    }

}

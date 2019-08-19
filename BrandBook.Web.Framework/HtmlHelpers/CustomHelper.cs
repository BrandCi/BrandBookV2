using System.Text;
using System.Web;
using BrandBook.Core.Repositories.Setting;
using BrandBook.Infrastructure.Data;
using BrandBook.Infrastructure.Repositories.Setting;

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

    }

}

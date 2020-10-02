using System.Configuration;
using System.Text;

namespace BrandCi.Web.Framework.Helpers
{
    public static class CustomHelper
    {
        #region Fields
        private static readonly string cdnServerUrl = ConfigurationManager.AppSettings["CdnServerUrl"];
        private static readonly string cdnServerKey = ConfigurationManager.AppSettings["CdnServerKey"];
        #endregion

        #region Static Methods
        public static string GetCdnBaseUrl()
        {
            return $"https://{cdnServerUrl}/{cdnServerKey}";
        }

        public static string GetImagePath(string imageName, string imageType, string area = "")
        {
            var imageFileName = $"{imageName}.{imageType}";

            return GetImagePath(imageFileName, area);
        }

        public static string GetImagePath(string imageName, string area = "")
        {
            var imagePath = new StringBuilder();

            imagePath.Append(GetCdnBaseUrl());

            if (!string.IsNullOrEmpty(area))
            {
                imagePath.Append($"/{area}");
            }

            imagePath.Append($"/{imageName}");


            return imagePath.ToString();
        }

        public static bool IsReCaptchaActive()
        {
            bool.TryParse(ConfigurationManager.AppSettings["ReCaptchaActive"], out var reCaptchaActive);
            return reCaptchaActive;
        }
        #endregion
    }
}

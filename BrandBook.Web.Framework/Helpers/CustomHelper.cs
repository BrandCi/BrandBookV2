using System;
using System.Configuration;
using System.Data.Entity.Infrastructure;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace BrandBook.Web.Framework.Helpers
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

        public static string GetCurrentDateTimeFormattedForNotification()
        {
            return DateTime.Now.ToString("dd.MM.yyyy HH:mm");
        }


        #region UserProfilePictures
        public static string GetUserimageFromGravatarOrLocal(string userEmailAddress, int size = 20)
        {
            return GetGravatarImageUrl(userEmailAddress, size);
        }

        public static string GetGravatarImageUrl(string userEmailAddress, int size)
        {
            var md5 = new MD5CryptoServiceProvider();

            var md5HashValues = Encoding.ASCII.GetBytes(userEmailAddress);
            md5HashValues = md5.ComputeHash(md5HashValues);

            var gravatarImageRequest = new StringBuilder("https://www.gravatar.com/avatar/");

            foreach(var value in md5HashValues)
            {
                gravatarImageRequest.Append(value.ToString("x2").ToLower());
            }

            gravatarImageRequest.Append($"?s={ size }");

            gravatarImageRequest.Append($"&d=retro");

            return gravatarImageRequest.ToString();
        }
        #endregion
        #endregion
    }
}

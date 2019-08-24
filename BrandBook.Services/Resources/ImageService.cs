using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace BrandBook.Services.Resources
{
    public class ImageService
    {

        public string GetImageType(string name)
        {
            var separatedImageName = name.Split('.');

            return separatedImageName[separatedImageName.Length - 1];
        }


        public string GenerateRandomImageName()
        {
            var random = new Random();

            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";

            return new string(Enumerable.Repeat(chars, 20)
                .Select(s => s[random.Next(s.Length)])
                .ToArray());
        }


    }
}

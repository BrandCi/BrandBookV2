using BrandBook.Services.Resources;
using NUnit.Framework;

namespace BrandBook.Services.Test
{
    [TestFixture]
    public class ImageServiceTests
    {
        private ImageService _imageService;


        [SetUp]
        public void SetUp()
        {
            _imageService = new ImageService();
        }



        [TestCase("image01.png", "png")]
        [TestCase("image.01.png", "png")]
        [TestCase("?_myImage.svg.png", "png")]
        [TestCase("image01.svg", "svg")]
        [TestCase("image01.i", "i")]
        public void GetImageType_WhenPassName_ReturnImageType(string imageName, string imageType)
        {
            var result = _imageService.GetImageType(imageName);

            Assert.That(result, Is.EqualTo(imageType));
        }




    }
}

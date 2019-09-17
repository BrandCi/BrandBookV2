using BrandBook.Services.Resources;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrandBook.Services.Test
{
    [TestClass]
    public class ImageServiceTests
    {
        private ImageService _imageService;

        [TestInitialize]
        public void TestInitialization()
        {
            _imageService = new ImageService();
        }


        [TestMethod]
        [DataRow("image01.png", "png")]
        [DataRow("image.01.png", "png")]
        [DataRow("?_myImage.svg.png", "png")]
        [DataRow("image01.svg", "svg")]
        [DataRow("image01.i", "i")]
        public void GetImageType_WhenPassName_ReturnImageType(string imageName, string expected)
        {
            var actual = _imageService.GetImageType(imageName);

            Assert.AreEqual(expected, actual);
        }
    }
}

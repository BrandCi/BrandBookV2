using System.Collections.Generic;
using BrandBook.Core.Services.Application;
using BrandBook.Services.Application;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BrandBook.Services.Test.Application
{
    [Ignore]
    [TestClass]
    public class BrandServiceTests
    {
        private IBrandService _brandService;

        [TestInitialize]
        public void TestInitialization()
        {
            _brandService = new BrandService();
        }

        [TestMethod]
        [DataRow("1", "https://fonts.googleapis.com/css?")]
        [DataRow("2", "https://fonts.googleapis.com/css?")]
        [DataRow("3", "https://fonts.googleapis.com/css?")]
        [DataRow("4", "https://fonts.googleapis.com/css?")]
        public void BuildGoogleFontLink_WhenPassFontId_ReturnFontLink(string fontId, string expected)
        {
            var googleFontLink = "";

            Assert.AreEqual(expected, googleFontLink);
        }

        [TestMethod]
        [DataRow(99, 47, 167,  41, 72, 0, 35)]
        [DataRow(220, 220, 151,  0, 84, 31, 14)]
        [DataRow(0, 0, 0, 0, 0, 0, 100)]
        [DataRow(0, 0, 0, 0, 0, 0, 0)]
        public void ConvertRgbToCmyk_WhenPassRgbValue_ReturnCorrectCmykConversion(int r, int g, int b, int expectedC, int expectedM, int expectedY, int expectedK)
        {
            var expectedList = new List<int>()
            {
                expectedC, expectedM, expectedY, expectedK
            };

            var cmykConversion = _brandService.ConvertRgbToCmyk(r, g, b);

            Assert.AreEqual(expectedList, cmykConversion);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using BrandBook.Core;
using BrandBook.Core.Services.Application;
using BrandBook.Infrastructure;

namespace BrandBook.Services.Application
{
    public class BrandService : IBrandService
    {
        #region Fields
        private readonly IUnitOfWork _unitOfWork;
        #endregion


        #region Constructor
        public BrandService()
        {
            _unitOfWork = new UnitOfWork();
        }
        #endregion


        #region Public Methods
        public string BuildGoogleFontLink(int fontId)
        {
            var googleFontLink = new StringBuilder();
            googleFontLink.Append("https://fonts.googleapis.com/css?");

            var font = _unitOfWork.FontRepository.FindById(fontId);

            googleFontLink.Append($"family={font.Family}:");

            var fontStyles = _unitOfWork.FontStyleRepository.GetAllForFont(fontId);

            foreach (var fontStyle in fontStyles)
            {
                googleFontLink.Append(fontStyle.Weight);

                if (fontStyle.Style == "italic")
                {
                    googleFontLink.Append("i");
                }

                googleFontLink.Append(",");
            }
            

            return googleFontLink.ToString();
        }


        public List<int> ConvertRgbToCmyk(int r, int g, int b)
        {
            var rConvert = r / 255F;
            var gConvert = g / 255F;
            var bConvert = b / 255F;

            var k = SaveCmyk(1 - Math.Max(Math.Max(rConvert, gConvert), bConvert));
            var c = SaveCmyk((1 - rConvert - k) / (1 - k));
            var m = SaveCmyk((1 - gConvert - k) / (1 - k));
            var y = SaveCmyk((1 - bConvert - k) / (1 - k));

            var cmyk = new List<int>();

            cmyk.Add(c);
            cmyk.Add(m);
            cmyk.Add(y);
            cmyk.Add(k);


            return cmyk;

        }
        #endregion


        #region Private Methods
        private int SaveCmyk(float value)
        {
            if (value < 0 || float.IsNaN(value))
            {
                value = 0;
            }

            return (int)Math.Round(value);
        }
        #endregion
    }
}

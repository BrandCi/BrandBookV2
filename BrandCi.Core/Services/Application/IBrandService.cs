using System.Collections.Generic;

namespace BrandBook.Core.Services.Application
{
    public interface IBrandService
    {
        string BuildGoogleFontLink(int fontId);
        List<int> ConvertRgbToCmyk(int r, int g, int b);
    }
}

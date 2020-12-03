using System.Collections.Generic;

namespace BrandCi.Core.Services.Application
{
    public interface IBrandService
    {
        string BuildGoogleFontLink(int fontId);
        List<int> ConvertRgbToCmyk(int r, int g, int b);
    }
}

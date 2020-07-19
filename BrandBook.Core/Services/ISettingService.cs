using System.Collections.Generic;
using System.Threading.Tasks;

namespace BrandBook.Core.Services
{
    public interface ISettingService
    {
        /// <summary>
        /// Get Setting Value from Database-Settings Pool
        /// </summary>
        /// <param name="settingKey"></param>
        /// <returns></returns>
        string GetSettingValueByKey(string settingKey);

        /// <summary>
        /// Update Setting Value in Database-Settings Pool
        /// </summary>
        /// <param name="settingKey"></param>
        /// <param name="newValue"></param>
        bool UpdateSettingValue(string settingKey, string newValue);

        /// <summary>
        /// Update Settings in Dictionary
        /// </summary>
        /// <param name="settingDictionary">Key, NewValue</param>
        /// <returns></returns>
        bool UpdateSettingsValue(Dictionary<string, string> settingDictionary);
    }
}

using System.Collections.Generic;

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
        /// Get Settings Values from Database-Settings Pool
        /// </summary>
        /// <param name="settingsKey"></param>
        /// <returns></returns>
        Dictionary<string, string> GetSettingsValueByKey(List<string> settingsKey);


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

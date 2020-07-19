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
        void UpdateSettingValue(string settingKey, string newValue);
    }
}

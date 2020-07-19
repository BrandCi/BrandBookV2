using BrandBook.Core;
using BrandBook.Core.Services;
using BrandBook.Infrastructure;
using System.Collections.Generic;

namespace BrandBook.Services
{
    public class SettingService : ISettingService
    {
        private readonly IUnitOfWork _unitOfWork;

        public SettingService()
        {
            _unitOfWork = new UnitOfWork();
        }



        public string GetSettingValueByKey(string settingKey)
        {
            var setting = _unitOfWork.SettingRepository.GetSettingByKey(settingKey);

            return setting?.Value;
        }

        public Dictionary<string, string> GetSettingsValueByKey(List<string> settingsKey)
        {
            var settingsValues = new Dictionary<string, string>();

            foreach (var settingKey in settingsKey)
            {
                var setting = _unitOfWork.SettingRepository.GetSettingByKey(settingKey);
                settingsValues.Add(settingKey, setting?.Value);
            }

            return settingsValues;
        }

        public bool UpdateSettingValue(string settingKey, string newValue)
        {
            var setting = _unitOfWork.SettingRepository.GetSettingByKey(settingKey);

            if (setting == null) return false;


            setting.Value = newValue;
            _unitOfWork.SettingRepository.Update(setting);

            _unitOfWork.SaveChanges();

            return true;
        }

        public bool UpdateSettingsValue(Dictionary<string, string> settingDictionary)
        {
            var successState = false;

            foreach (var settingKeyValue in settingDictionary)
            {
                var setting = _unitOfWork.SettingRepository.GetSettingByKey(settingKeyValue.Key);

                if (setting == null)
                {
                    successState = false;
                    continue;
                }

                setting.Value = settingKeyValue.Value;
                _unitOfWork.SettingRepository.Update(setting);
                successState = true;
            }


            if (!successState) return false;

            _unitOfWork.SaveChangesAsync();
            return true;
        }
    }
}

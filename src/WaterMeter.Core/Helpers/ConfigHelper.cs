using System;
using System.Configuration;

namespace WaterMeter.Core.Helpers
{
    public static class ConfigHelper
    {
        public static T GetValue<T>(string areaName, string configName)
        {
            var key = $"{areaName}:{configName}";
            var rawValue = ConfigurationManager.AppSettings[key];

            if (string.IsNullOrEmpty(rawValue))
            {
                throw new Exception($"Application setting '{key}' is required");
            }
            return (T)Convert.ChangeType(rawValue, typeof(T));
        }
    }
}
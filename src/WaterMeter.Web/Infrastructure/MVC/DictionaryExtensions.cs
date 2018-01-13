using System.Collections.Generic;

namespace WaterMeter.Web.Infrastructure.MVC
{
    public static class DictionaryExtensions
    {
        public static Dictionary<string, object> WithValue(this Dictionary<string, object> htmlDictionary, string key, object value, bool replaceExistingValue = true)
        {
            var result = new Dictionary<string, object>(htmlDictionary);

            if (result.ContainsKey(key))
            {
                if (replaceExistingValue)
                {
                    result[key] = value;
                }
            }
            else
            {
                result.Add(key, value);
            }

            return result;
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Routing;

namespace WaterMeter.Web.Infrastructure.MVC
{
    public static class HtmlAttributesExtensions
    {
        public static Dictionary<string, object> ToDictionary(this object htmlAttributes)
        {
            if (htmlAttributes is Dictionary<string, object> dictionary)
            {
                return dictionary;
            }

            if (htmlAttributes is RouteValueDictionary routeValueDictionary)
            {
                return routeValueDictionary.ToDictionary(x => x.Key.Replace('_', '-'), x => x.Value);
            }

            var result = new Dictionary<string, object>();
            if (htmlAttributes != null)
            {
                foreach (var prop in htmlAttributes.GetType().GetProperties(BindingFlags.Instance | BindingFlags.Public))
                {
                    result.Add(prop.Name.Replace('_', '-'), prop.GetValue(htmlAttributes, null));
                }
            }

            return result;
        }
    }
}
using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace WaterMeter.Web.Infrastructure.MVC
{
    public static class UrlHelperExtensions
    {
        public static string Action<T>(this UrlHelper url, Expression<Func<T, object>> expression, object routeValues = null, bool includeHost = false) where T : ControllerBase
        {
            var controllerName = ActionExpressionHelper.GetControllerNameFromExpression(expression);
            var actionName = ActionExpressionHelper.GetActionNameFromExpression(expression);
            var routeValueDictionary = ActionExpressionHelper.GetRouteValuesFromExpression(expression);

            if (routeValues != null)
            {
                routeValueDictionary = new RouteValueDictionary(routeValues.ToDictionary());
            }

            return url.Action(actionName, controllerName, routeValueDictionary, includeHost ? url.RequestContext?.HttpContext?.Request?.Url?.Scheme : null);
        }
    }
}
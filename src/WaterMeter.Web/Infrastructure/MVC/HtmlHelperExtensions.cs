using System;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace WaterMeter.Web.Infrastructure.MVC
{
    public static class HtmlHelperExtensions
    {
        public static MvcHtmlString ActionLink<T>(this HtmlHelper html, string linkText, Expression<Func<T, object>> expression, object routeValues = null, object htmlAttributes = null) where T : ControllerBase
        {
            var controllerName = ActionExpressionHelper.GetControllerNameFromExpression(expression);
            var actionName = ActionExpressionHelper.GetActionNameFromExpression(expression);
            var routeValueDictionary = ActionExpressionHelper.GetRouteValuesFromExpression(expression);

            if (routeValues != null)
            {
                routeValueDictionary = new RouteValueDictionary(routeValues.ToDictionary());
            }

            return html.ActionLink(linkText, actionName, controllerName, routeValueDictionary, htmlAttributes?.ToDictionary());
        }

        public static void RenderAction<T>(this HtmlHelper html, Expression<Func<T, object>> expression, object routeValues = null) where T : ControllerBase
        {
            var controllerName = ActionExpressionHelper.GetControllerNameFromExpression(expression);
            var actionName = ActionExpressionHelper.GetActionNameFromExpression(expression);
            var routeValueDictionary = ActionExpressionHelper.GetRouteValuesFromExpression(expression);

            if (routeValues != null)
            {
                routeValueDictionary = new RouteValueDictionary(routeValues.ToDictionary());
            }

            html.RenderAction(actionName, controllerName, routeValueDictionary);
        }

        public static MvcForm BeginForm<T>(this HtmlHelper html, Expression<Func<T, object>> expression, FormMethod formMethod = FormMethod.Post, object htmlAttributes = null) where T : ControllerBase
        {
            var controllerName = ActionExpressionHelper.GetControllerNameFromExpression(expression);
            var actionName = ActionExpressionHelper.GetActionNameFromExpression(expression);
            var routeValueDictionary = ActionExpressionHelper.GetRouteValuesFromExpression(expression);

            return html.BeginForm(actionName, controllerName, routeValueDictionary, formMethod, htmlAttributes?.ToDictionary());
        }
    }
}
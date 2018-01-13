using System;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using System.Web.Routing;

namespace WaterMeter.Web.Infrastructure.MVC
{
    public static class ActionExpressionHelper
    {
        public static string GetActionNameFromExpression<T>(Expression<Func<T, object>> expression) where T : ControllerBase
        {
            var methodCallExpression = expression.Body as MethodCallExpression;
            if (methodCallExpression == null)
            {
                throw new ArgumentException("Not a MethodCallExpression", nameof(expression));
            }

            var actionName = methodCallExpression.Method.Name;

            return actionName;
        }

        public static string GetControllerNameFromExpression<T>(Expression<Func<T, object>> expression) where T : ControllerBase
        {
            return typeof(T).Name.Replace(nameof(Controller), string.Empty);
        }

        public static RouteValueDictionary GetRouteValuesFromExpression<T>(Expression<Func<T, object>> expression) where T : ControllerBase
        {
            var methodCallExpression = expression.Body as MethodCallExpression;
            if (methodCallExpression == null)
            {
                throw new ArgumentException("Not a MethodCallExpression", nameof(expression));
            }

            var methodParameters = methodCallExpression.Method.GetParameters();
            var routeValueArguments = methodCallExpression.Arguments.Select(EvaluateExpression);

            var rawRouteValueDictionary = methodParameters.Select(m => m.Name)
                .Zip(routeValueArguments, (parameter, argument) => new
                {
                    parameter,
                    argument
                })
                .ToDictionary(kvp => kvp.parameter, kvp => kvp.argument);

            var routeValueDictionary = new RouteValueDictionary(rawRouteValueDictionary);

            return routeValueDictionary;
        }
        private static object EvaluateExpression(Expression expression)
        {
            var constExpr = expression as ConstantExpression;
            if (constExpr != null)
            {
                return constExpr.Value;
            }

            var lambda = Expression.Lambda(expression);
            var compiled = lambda.Compile();

            return compiled.DynamicInvoke();
        }
    }
}
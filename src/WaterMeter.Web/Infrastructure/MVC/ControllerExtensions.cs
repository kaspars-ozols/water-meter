using System;
using System.Linq.Expressions;
using System.Web.Mvc;

namespace WaterMeter.Web.Infrastructure.MVC
{
    public static class ControllerExtensions
    {
        public static ActionResult RedirectToAction<T>(this T controller, Expression<Func<T, object>> expression) where T : Controller
        {
            return RedirectToAction(controller, expression, null);
        }

        public static ActionResult RedirectToAction<T>(this Controller controller, Expression<Func<T, object>> expression) where T : ControllerBase
        {
            return RedirectToAction(controller, expression, null);
        }

        public static ActionResult RedirectToAction<T>(this Controller controller, Expression<Func<T, object>> expression, object routeValues, bool includeHost = false)
            where T : ControllerBase
        {
            var url = controller.Url.Action(expression, routeValues, includeHost);

            return new RedirectResult(url);
        }
    }
}

    
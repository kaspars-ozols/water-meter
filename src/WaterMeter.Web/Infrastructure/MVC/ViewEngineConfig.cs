using System.Web.Mvc;

namespace WaterMeter.Web.Infrastructure
{
    public static class ViewEngineConfig
    {
        public static void RegisterFeatureViewEngine()
        {
            ViewEngines.Engines.Clear();
            ViewEngines.Engines.Add(new FeatureViewEngine());
        }
    }
}
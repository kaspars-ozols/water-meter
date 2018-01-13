using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;

namespace WaterMeter.Web.Infrastructure
{
    public class FeatureViewEngine : RazorViewEngine
    {
        public FeatureViewEngine()
        {
            var featureFolderViewLocationFormats = new[]
                {
                    "~/Features/{0}.cshtml",
                    "~/Features/{1}/{0}.cshtml",
                    "~/Features/{1}/Views/{0}.cshtml"
                }
                .Union(FeatureFolders())
                .ToArray();

            ViewLocationFormats = ViewLocationFormats.Union(featureFolderViewLocationFormats).ToArray();
            MasterLocationFormats = MasterLocationFormats.Union(featureFolderViewLocationFormats).ToArray();
            PartialViewLocationFormats = PartialViewLocationFormats.Union(featureFolderViewLocationFormats).ToArray();
        }

        private IEnumerable<string> FeatureFolders()
        {
            var rootFolder = HostingEnvironment.MapPath("~/Features/");
            if (rootFolder == null)
            {
                return Enumerable.Empty<string>();
            }

            var relativeFeaturePaths = Directory.GetDirectories(rootFolder, "*", SearchOption.AllDirectories)
                .Select(x => GetRelativeFeaturePath(x, rootFolder));

            return relativeFeaturePaths
                .SelectMany(
                    dir => new[]
                    {
                        $"~/Features/{dir}/{{0}}.cshtml",
                        $"~/Features/{dir}/{{1}}/{{0}}.cshtml",
                        $"~/Features/{dir}/{{1}}/Views/{{1}}.cshtml"
                    });
        }

        private string GetRelativeFeaturePath(string path, string rootFolder)
        {
            return path.Replace(rootFolder, string.Empty).Replace('\\', '/');
        }
    }
}
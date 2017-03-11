using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using RazorEngine;
using RazorEngine.Templating;

namespace WaterMeter.Services.Templating
{
   public  class RazorTemplateRenderer: ITemplateRenderer
    {
        public string Render<TModel>(string templateFile, TModel model, object templateArgs = null)
        {
            var template = File.ReadAllText(templateFile);
            var templateKey = GetMd5Hash(template);

            var dictionary = HtmlHelper.ObjectToDictionary(templateArgs);
            var viewBag = new DynamicViewBag(dictionary);

            var source = new LoadedTemplateSource(template, templateFile);
            var result = Engine.Razor.RunCompile(source, templateKey, null, model, viewBag);

            return result;
        }

        private static string GetMd5Hash(string input)
        {
            var md5 = MD5.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            var hash = md5.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            foreach (var t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}

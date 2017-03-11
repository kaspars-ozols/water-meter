using System.IO;
using System.Security.Cryptography;
using System.Text;
using RazorEngine;
using RazorEngine.Templating;

namespace WaterMeter.ScheduledJob.Rendering
{
   public  class RazorRenderer
    {
        public string Render<T>(string templateName, T model)
        {

            var templateFile = $"Templates/{templateName}.cshtml";
            var template = File.ReadAllText(templateFile);
            var templateKey = GetMd5Hash(template);

            var source = new LoadedTemplateSource(template, templateFile);
            var result = Engine.Razor.RunCompile(source, templateKey, null, model);

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

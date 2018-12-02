using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HtmlLocalization
{
    public class HtmlLocalizator
    {
        public static string OpenToken { get; set; } = "{{";
        public static string CloseToken { get; set; } = "}}";

        public string LocalizeHtmlFromDictionary(string html, Dictionary<string, string> keyValues)
        {
            var sb = new StringBuilder(html);

            foreach (var item in keyValues)
            {
                sb.Replace($"{OpenToken}{item.Key}{CloseToken}", item.Value);
            }

            return sb.ToString();
        }

        public string LocalizeHtmlFromClass(string html, object @pbject)
        {
            var dictionary = @pbject.GetType()
                                    .GetProperties(BindingFlags.Instance | BindingFlags.Public)
                                    .ToDictionary(prop => prop.Name, prop => prop.GetValue(@pbject, null)?.ToString());

            return this.LocalizeHtmlFromDictionary(html, dictionary);

        }
    }
}

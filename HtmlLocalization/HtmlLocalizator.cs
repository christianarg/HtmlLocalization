using System;
using System.Collections.Generic;
using System.Globalization;
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

        /// <summary>
        /// Default single instance.
        /// </summary>
        public static HtmlLocalizator Instance { get; set; } = new HtmlLocalizator();

        public string LocalizeHtml(HtmlLocalized htmlLocalized, CultureInfo cultureInfo = null)
        {
            return LocalizeHtmlFromDictionary(htmlLocalized.Template, htmlLocalized.GetTextByLanguage(cultureInfo ?? CultureInfo.CurrentCulture));
        }

        public string LocalizeHtmlFromDictionary(string html, IDictionary<string, string> keyValues)
        {
            var sb = new StringBuilder(html);

            foreach (var item in keyValues)
            {
                sb.Replace($"{OpenToken}{item.Key}{CloseToken}", item.Value);
            }

            return sb.ToString();
        }

        //public string LocalizeHtmlFromClass(string html, object @pbject)
        //{
        //    var dictionary = @pbject.GetType()
        //                            .GetProperties(BindingFlags.Instance | BindingFlags.Public)
        //                            .ToDictionary(prop => prop.Name, prop => prop.GetValue(@pbject, null)?.ToString());

        //    return this.LocalizeHtmlFromDictionary(html, dictionary);

        //}
    }
}

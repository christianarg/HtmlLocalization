using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HtmlLocalization
{
    public class HtmlLocalized
    {
        public IDictionary<string, IDictionary<string, string>> TextsPerLanguage { get; set; } = new Dictionary<string, IDictionary<string, string>>();

        public string Template { get; set; }

        public void RegisterTextsByLanguage(CultureInfo culture, IDictionary<string,string> textsByLanguage)
        {
            TextsPerLanguage[culture.Name] = textsByLanguage;
        }

        public IDictionary<string, string> GetTextByLanguage(CultureInfo cultureInfo)
        {
            if (!TextsPerLanguage.ContainsKey(cultureInfo.Name))
            {
                return new Dictionary<string, string>();
            }
            return TextsPerLanguage[cultureInfo.Name];
        }
    }

    /// <summary>
    /// Class to be inherited to create a HtmlLocalized component.
    /// 
    /// The idea is that the Configre method has all localizations and so read and fill all texts by language.
    /// 
    /// Works best with 2 or 3 languages
    /// </summary>
    public abstract class HtmlLocalizedComponent : HtmlLocalized
    {
        public abstract void Configure();

        public string ReadEmbededFile(Type type, string resourceName)
        {
            return EmbeddedFileUtil.ReadEmbeded(type, resourceName);
        }

        public string ReadEmbededFile(Assembly assembly, string resourceName)
        {
            return EmbeddedFileUtil.ReadEmbeded(assembly, resourceName);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
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
}

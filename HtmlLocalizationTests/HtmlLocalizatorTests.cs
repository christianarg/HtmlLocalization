using HtmlLocalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace HtmlLocalizationTests
{
    [TestClass]
    public class HtmlLocalizatorTests
    {
        HtmlLocalizator htmlLocalizator;

        [TestInitialize]
        public void Init()
        {
            htmlLocalizator = new HtmlLocalizator();
        }

        [TestMethod]
        public void LocalizeFromDictionarySimple()
        {
            // ARRANGE
            var keyValue1 = new KeyValuePair<string, string>("[[key1]]", "Contenido del párrafo");

            string inputHtml = $"<p>{keyValue1.Key}</p>";
            
            // ACT
            var result = htmlLocalizator.LocalizeHtmlFromDictionary(inputHtml, new Dictionary<string, string> { { keyValue1.Key, keyValue1.Value } });

            htmlLocalizator.LocalizeHtmlFromDictionary(inputHtml, new Dictionary<string, string> { { keyValue1.Key, keyValue1.Value } });
            
            // ASSERT
            Assert.AreEqual($"<p>{keyValue1.Value}</p>", result);
        }
    }
}

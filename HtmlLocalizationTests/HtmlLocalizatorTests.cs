using HtmlLocalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Reflection;

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

            string inputHtml = "<p>{{key1}}</p>";

            // ACT
            var result = htmlLocalizator.LocalizeHtmlFromDictionary(inputHtml, new Dictionary<string, string> { { "key1", "Contenido del párrafo" } });

            // ASSERT
            Assert.AreEqual("<p>Contenido del párrafo</p>", result);
        }

        [TestMethod]
        public void LocalizeFromDictionaryFromEmbeded()
        {
            // ARRANGE
            
            var assembly = Assembly.GetAssembly(this.GetType());
            string template = ReadEmbeded(assembly, "HtmlLocalizationTests.someText.html");
            var texts = new Dictionary<string, string>
            {
                { "prerequisitosSomeDesc", "Contenido del párrafo" },
                { "availableLicenesOfAnyPrerequisite", "Contenido del párrafo" },
                { "totalLicencesOfAnyPrerequisiteToPurchaseNeededCount", "Contenido del párrafo" },
                { "alreadyAvailableText", "Contenido del párrafo" },
            };

            // ACT
            var result = htmlLocalizator.LocalizeHtmlFromDictionary(template, texts);

            // ASSERT
            foreach (var key in texts.Keys)
            {
                Assert.IsFalse(result.Contains(key));
            }

            foreach (var values in texts.Values)
            {
                Assert.IsTrue(result.Contains(values));
            }
        }

        private string ReadEmbeded(Assembly assembly, string resourceName)
        {
            using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            using (StreamReader reader = new StreamReader(stream))
            {
                string result = reader.ReadToEnd();
                return result;
            }
        }
    }
}

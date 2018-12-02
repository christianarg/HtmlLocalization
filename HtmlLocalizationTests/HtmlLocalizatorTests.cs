using HtmlLocalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Reflection;

namespace HtmlLocalizationTests
{
    [TestClass]
    public class HtmlLocalizatorTests : TestBase
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
            var result = htmlLocalizator.LocalizeHtmlFromDictionary(inputHtml, new Dictionary<string, string> { { "key1", "Contenido del p�rrafo" } });

            // ASSERT
            Assert.AreEqual("<p>Contenido del p�rrafo</p>", result);
        }

        [TestMethod]
        public void LocalizeFromDictionaryFromEmbeded()
        {
            // ARRANGE

            string template = EmbeddedFileUtil.ReadEmbeded("HtmlLocalizationTests.someText.html");

            var texts = new Dictionary<string, string>
            {
                { "prerequisitosSomeDesc", "Contenido del p�rrafo" },
                { "availableLicenesOfAnyPrerequisite", "Contenido del p�rrafo" },
                { "totalLicencesOfAnyPrerequisiteToPurchaseNeededCount", "Contenido del p�rrafo" },
                { "alreadyAvailableText", "Contenido del p�rrafo" },
            };

            // ACT
            var result = htmlLocalizator.LocalizeHtmlFromDictionary(template, texts);

            // ASSERT
            AssertReplacements(texts, result);
        }
    }
}

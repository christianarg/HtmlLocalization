using HtmlLocalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading;

namespace HtmlLocalizationTests
{
    [TestClass]
    public class HtmlLocalizatedTests : TestBase
    {
        HtmlLocalizator htmlLocalizator;

        CultureInfo spanish = CultureInfo.GetCultureInfo("es-ES");
        CultureInfo english = CultureInfo.GetCultureInfo("en-US");

        [TestInitialize]
        public void Init()
        {
            htmlLocalizator = new HtmlLocalizator();
        }

        [TestMethod]
        public void LocalizeFromDictionaryFromEmbeded()
        {
            // ARRANGE
            var htmlLocalized = new HtmlLocalized();
            htmlLocalized.Template = EmbeddedFileUtil.ReadEmbeded("HtmlLocalizationTests.someText.html");


            var textsEs = new Dictionary<string, string>
            {
                { "prerequisitosSomeDesc", "Contenido del párrafo" },
                { "availableLicenesOfAnyPrerequisite", "Contenido del párrafo" },
                { "totalLicencesOfAnyPrerequisiteToPurchaseNeededCount", "Contenido del párrafo" },
                { "alreadyAvailableText", "Contenido del párrafo" },
            };

            htmlLocalized.RegisterTextsByLanguage(spanish, textsEs);

            var textsEn = new Dictionary<string, string>
            {
                { "prerequisitosSomeDesc", "Some Content 1" },
                { "availableLicenesOfAnyPrerequisite", "Some Content 2" },
                { "totalLicencesOfAnyPrerequisiteToPurchaseNeededCount", "Some Content 3" },
                { "alreadyAvailableText", "Some Content 4" },
            };

            htmlLocalized.RegisterTextsByLanguage(english, textsEn);

            // ACT
            Thread.CurrentThread.CurrentCulture = spanish;
            var resultEs = htmlLocalizator.LocalizeHtml(htmlLocalized);

            Thread.CurrentThread.CurrentCulture = english;
            var resultEn = htmlLocalizator.LocalizeHtml(htmlLocalized);

            // ASSERT
            AssertReplacements(textsEs, resultEs);
            AssertReplacements(textsEn, resultEn);
        }
    }
}

using HtmlLocalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Globalization;
using System.Reflection;
using System.Threading;

namespace HtmlLocalizationTests
{
    [TestClass]
    public class SomeHtmlLocalizedComponentTests : TestBase
    {
        CultureInfo spanish = CultureInfo.GetCultureInfo("es-ES");
        CultureInfo english = CultureInfo.GetCultureInfo("en-US");

        [TestMethod]
        public void LocalizeFromDictionaryFromEmbeded()
        {
            // ARRANGE
            var localizedComponent = new SomeHtmlLocalizedComponent();

            // ACT
            Thread.CurrentThread.CurrentCulture = spanish;
            var resultEs = HtmlLocalizator.Instance.LocalizeHtml(localizedComponent);

            Thread.CurrentThread.CurrentCulture = english;
            var resultEn = HtmlLocalizator.Instance.LocalizeHtml(localizedComponent);

            // ASSERT
            AssertReplacements(localizedComponent.TextsPerLanguage[spanish.Name], resultEs);
            AssertReplacements(localizedComponent.TextsPerLanguage[english.Name], resultEn);
        }
    }

    public class SomeHtmlLocalizedComponent : HtmlLocalizedComponent
    {
        public SomeHtmlLocalizedComponent()
        {
            Configure();
        }

        public override void Configure()
        {
            Template = ReadEmbededFile(this.GetType(), "HtmlLocalizationTests.someText.html");

            RegisterTextsByLanguage(CultureInfo.GetCultureInfo("es-ES"), new Dictionary<string, string>
            {
                { "prerequisitosSomeDesc", "Contenido del párrafo1" },
                { "availableLicenesOfAnyPrerequisite", "Contenido del párrafo2" },
                { "totalLicencesOfAnyPrerequisiteToPurchaseNeededCount", "Contenido del párrafo3" },
                { "alreadyAvailableText", "Contenido del párrafo4" },
            });

            RegisterTextsByLanguage(CultureInfo.GetCultureInfo("en-US"), new Dictionary<string, string>
            {
                { "prerequisitosSomeDesc", "Some Content 1" },
                { "availableLicenesOfAnyPrerequisite", "Some Content 2" },
                { "totalLicencesOfAnyPrerequisiteToPurchaseNeededCount", "Some Content 3" },
                { "alreadyAvailableText", "Some Content 4" },
            });
        }
    }
}

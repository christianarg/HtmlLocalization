using HtmlLocalization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlLocalizationTests
{
    public class TestBase
    {
        protected string ReadEmbededFile(string resourceName)
        {
            return EmbeddedFileUtil.ReadEmbeded(typeof(TestBase).Assembly, resourceName);
        }

        protected void AssertReplacements(IDictionary<string, string> texts, string result)
        {
            foreach (var key in texts.Keys)
            {
                Assert.IsFalse(result.Contains(key));
            }

            foreach (var values in texts.Values)
            {
                Assert.IsTrue(result.Contains(values));
            }
        }
    }
}

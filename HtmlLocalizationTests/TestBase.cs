using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HtmlLocalizationTests
{
    public class TestBase
    {
        protected void AssertReplacements(Dictionary<string, string> texts, string result)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpApi.Test
{
    internal static class JObjectExtensions
    {
        public static void AssertAreEqual<T>(this JObject o, string propertyName, T expected)
        {
            var actual = o.Value<T>(propertyName);
            Assert.AreEqual(expected, actual);
        }
    }
}

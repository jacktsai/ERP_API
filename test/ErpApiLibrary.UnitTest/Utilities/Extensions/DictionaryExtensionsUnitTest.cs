using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpApi.System.Collections.Generic
{
    [TestClass]
    public class DictionaryExtensionsUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Null_Target()
        {
            Dictionary<string, object> target = null;
            target.GetOrDefault(string.Empty);
        }

        [TestMethod]
        public void Value_Exists()
        {
            var key = "key";
            var expected = "hello world!";

            Dictionary<string, object> target = new Dictionary<string, object>();
            target.Add(key, expected);
            var actual = target.GetOrDefault(key);

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void Value_Is_Null()
        {
            var key = "key";

            Dictionary<string, object> target = new Dictionary<string, object>();
            target.Add(key, null);
            var actual = target.GetOrDefault(key);

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void Value_Not_Exists()
        {
            var key = "key";

            Dictionary<string, object> target = new Dictionary<string, object>();
            var actual = target.GetOrDefault(key);

            Assert.IsNull(actual);
        }
    }
}

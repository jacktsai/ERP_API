using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data.Common;

namespace Yahoo.DataAccess.Common
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var r = DbProviderFactories.GetFactoryClasses();
        }
    }
}

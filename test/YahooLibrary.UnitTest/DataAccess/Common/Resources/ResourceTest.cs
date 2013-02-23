using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yahoo.DataAccess.Common.Resources
{
    [TestClass]
    public class ResourceTest
    {
        [TestMethod]
        public void Constructor()
        {
            var dao = new PrivilegeDao();
            var actual = new Resource(dao);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_dao_null()
        {
            var actual = new Resource(null);
        }

        [TestMethod]
        public void GetString()
        {
            var dao = new PrivilegeDao();
            var target = new Resource(dao);
            var actual = target.GetString("GetMany.sql");
            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Contains("SELECT"));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetString_resourceName_null()
        {
            var dao = new PrivilegeDao();
            var target = new Resource(dao);
            var actual = target.GetString(null);
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpApi.Data.Common
{
    [TestClass]
    public class RoleDaoTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetMany_userId_0_url_null()
        {
            IRoleDao target = new RoleDao();
            target.GetMany(0, null);
        }

        [TestMethod]
        public void GetMany_userId_2733_url_testaspx()
        {
            IRoleDao target = new RoleDao();
            var actual = target.GetMany(2733, "/test.aspx");

            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count());
        }

        [TestMethod]
        public void GetMany_userId_2733_url_UserMgmtaspx()
        {
            IRoleDao target = new RoleDao();
            var actual = target.GetMany(2733, "/Security/Privilege/UserMgmt.aspx");

            Assert.IsNotNull(actual);
            Assert.AreEqual(5, actual.Count());
            Assert.IsTrue(actual.Any(o => o.Name == "Administrators"));
            Assert.IsTrue(actual.Any(o => o.Name == "Select"));
            Assert.IsTrue(actual.Any(o => o.Name == "Insert"));
            Assert.IsTrue(actual.Any(o => o.Name == "Update"));
            Assert.IsTrue(actual.Any(o => o.Name == "Delete"));
        }
    }
}

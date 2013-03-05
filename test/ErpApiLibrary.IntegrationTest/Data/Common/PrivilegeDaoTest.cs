using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpApi.Data.Common
{
    [TestClass]
    public class PrivilegeDaoTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void GetMany_userId_2733()
        {
            IPrivilegeDao target = new PrivilegeDao();
            var actual = target.GetManyAsync(2733).Result;

            Assert.AreNotEqual(0, actual.Count());
        }

        [TestMethod]
        public void GetMany_userId_negative()
        {
            var target = new PrivilegeDao() as IPrivilegeDao;
            var actual = target.GetManyAsync(userId: -1).Result;

            Assert.AreEqual(0, actual.Count());
        }
    }
}

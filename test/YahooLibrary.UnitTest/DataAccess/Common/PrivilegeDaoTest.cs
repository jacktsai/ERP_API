using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Yahoo.DataAccess.Common
{
    [TestClass]
    public class PrivilegeDaoTest
    {
        public TestContext TestContext { get; set; }

        [TestMethod]
        public void GetMany_userId_2733()
        {
            var target = new PrivilegeDao() as IPrivilegeDao;
            var actual = target.GetMany(userId: 2733);

            Assert.AreEqual(308, actual.Count());
            foreach (var o in actual)
            {
                TestContext.WriteLine("FunctionId: {0}", o.FunctionId);
            }
        }

        [TestMethod]
        public void GetMany_userId_null()
        {
            var target = new PrivilegeDao() as IPrivilegeDao;
            var actual = target.GetMany(userId: null);

            Assert.AreEqual(0, actual.Count());
        }

        [TestMethod]
        public void GetMany_userId_negative()
        {
            var target = new PrivilegeDao() as IPrivilegeDao;
            var actual = target.GetMany(userId: -1);

            Assert.AreEqual(0, actual.Count());
        }
    }
}

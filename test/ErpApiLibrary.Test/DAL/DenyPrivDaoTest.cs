using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpApi.DAL
{
    [TestClass]
    public class DenyPrivDaoTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOne_userId_0_url_null()
        {
            IDenyPrivDao target = new DenyPrivDao();
            target.GetOne(0, null);
        }

        [TestMethod]
        public void GetOne_userId_2733_url_testaspx()
        {
            IDenyPrivDao target = new DenyPrivDao();
            var actual = target.GetOne(2733, "/test.aspx");

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetOne_userId_2733_url_UserMgmtaspx()
        {
            IDenyPrivDao target = new DenyPrivDao();
            var actual = target.GetOne(2733, "/Security/Privilege/UserMgmt.aspx");

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetOne_userId_573_url_PayQueryaspx()
        {
            IDenyPrivDao target = new DenyPrivDao();
            var actual = target.GetOne(573, "/erp/pay/pay_query.asp");

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.Select);
            Assert.IsTrue(actual.Insert);
            Assert.IsTrue(actual.Update);
            Assert.IsTrue(actual.Delete);
            Assert.IsTrue(actual.Particular);
        }

        [TestMethod]
        public void GetOne_userId_2699_url_GroupMgmtaspx()
        {
            IDenyPrivDao target = new DenyPrivDao();
            var actual = target.GetOne(2699, "/Security/Privilege/GroupMgmt.aspx");

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.Select);
            Assert.IsTrue(actual.Insert);
            Assert.IsFalse(actual.Update);
            Assert.IsFalse(actual.Delete);
            Assert.IsFalse(actual.Particular);
        }
    }
}

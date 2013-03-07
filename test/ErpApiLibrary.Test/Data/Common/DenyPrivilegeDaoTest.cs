using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpApi.Data.Common
{
    [TestClass]
    public class DenyPrivilegeDaoTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOne_userId_0_url_null()
        {
            IDenyPrivilegeDao target = new DenyPrivilegeDao();
            target.GetOne(0, null);
        }

        [TestMethod]
        public void GetOne_userId_2733_url_testaspx()
        {
            IDenyPrivilegeDao target = new DenyPrivilegeDao();
            var actual = target.GetOne(2733, "/test.aspx");

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetOne_userId_2733_url_UserMgmtaspx()
        {
            IDenyPrivilegeDao target = new DenyPrivilegeDao();
            var actual = target.GetOne(2733, "/Security/Privilege/UserMgmt.aspx");

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetOne_userId_573_url_PayQueryaspx()
        {
            IDenyPrivilegeDao target = new DenyPrivilegeDao();
            var actual = target.GetOne(573, "/erp/pay/pay_query.asp");

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.DenySelect);
            Assert.IsTrue(actual.DenyInsert);
            Assert.IsTrue(actual.DenyUpdate);
            Assert.IsTrue(actual.DenyDelete);
            Assert.IsTrue(actual.DenyParticular);
        }

        [TestMethod]
        public void GetOne_userId_2699_url_GroupMgmtaspx()
        {
            IDenyPrivilegeDao target = new DenyPrivilegeDao();
            var actual = target.GetOne(2699, "/Security/Privilege/GroupMgmt.aspx");

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.DenySelect);
            Assert.IsTrue(actual.DenyInsert);
            Assert.IsFalse(actual.DenyUpdate);
            Assert.IsFalse(actual.DenyDelete);
            Assert.IsFalse(actual.DenyParticular);
        }
    }
}

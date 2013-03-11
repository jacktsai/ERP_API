using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpApi.DAL
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
            Assert.IsTrue(actual.denyprivs_select);
            Assert.IsTrue(actual.denyprivs_insert);
            Assert.IsTrue(actual.denyprivs_update);
            Assert.IsTrue(actual.denyprivs_delete);
            Assert.IsTrue(actual.denyprivs_particular);
        }

        [TestMethod]
        public void GetOne_userId_2699_url_GroupMgmtaspx()
        {
            IDenyPrivilegeDao target = new DenyPrivilegeDao();
            var actual = target.GetOne(2699, "/Security/Privilege/GroupMgmt.aspx");

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.denyprivs_select);
            Assert.IsTrue(actual.denyprivs_insert);
            Assert.IsFalse(actual.denyprivs_update);
            Assert.IsFalse(actual.denyprivs_delete);
            Assert.IsFalse(actual.denyprivs_particular);
        }
    }
}

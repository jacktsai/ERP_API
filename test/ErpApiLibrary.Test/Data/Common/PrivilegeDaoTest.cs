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
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOne_backyardId_null_url_null()
        {
            IPrivilegeDao target = new PrivilegeDao();
            target.GetOne(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOne_backyardId_null_url_Empty()
        {
            IPrivilegeDao target = new PrivilegeDao();
            target.GetOne(null, string.Empty);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetOne_backyardId_Empty_url_null()
        {
            IPrivilegeDao target = new PrivilegeDao();
            target.GetOne(string.Empty, null);
        }

        [TestMethod]
        public void GetOne_backyardId_jacktsai_url_testaspx()
        {
            IPrivilegeDao target = new PrivilegeDao();
            var actual = target.GetOne("jacktsai", "/test.aspx");

            Assert.IsNotNull(actual);
            Assert.AreEqual(150117, actual.Id);
            Assert.AreEqual(2733, actual.UserId);
            Assert.AreEqual(873, actual.FunctionId);
            Assert.AreEqual("新使用者建立(ctr_AssignUserBasicPrivs)", actual.Note);
        }
    }
}

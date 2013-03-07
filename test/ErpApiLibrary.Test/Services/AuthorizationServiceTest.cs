using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpApi.Data.Common;
using ErpApi.Data;

namespace ErpApi.Services
{
    [TestClass]
    public class AuthorizationServiceTest
    {
        private IDaoFactory factory;

        [TestInitialize]
        public void TestInitialize()
        {
            this.factory = new CommonDaoFactory();
        }

        [TestMethod]
        public void GetAuthority_backyardId_jacktsai_url_testaspx()
        {
            IAuthorizationService target = new AuthorizationService(this.factory);
            var actual = target.GetAuthority("jacktsai", "/test.aspx");

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.CanSelect);
            Assert.IsTrue(actual.CanInsert);
            Assert.IsTrue(actual.CanUpdate);
            Assert.IsTrue(actual.CanDelete);
            Assert.IsTrue(actual.CanParticular);
        }

        [TestMethod]
        public void GetAuthority_backyardId_jacktsai_url_usermgmtaspx()
        {
            IAuthorizationService target = new AuthorizationService(this.factory);
            var actual = target.GetAuthority("jacktsai", "/Security/Privilege/UserMgmt.aspx");

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.CanSelect);
            Assert.IsTrue(actual.CanInsert);
            Assert.IsTrue(actual.CanUpdate);
            Assert.IsTrue(actual.CanDelete);
            Assert.IsTrue(actual.CanParticular);
        }
    }
}

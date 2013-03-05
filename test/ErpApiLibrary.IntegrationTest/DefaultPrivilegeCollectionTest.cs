using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpApi.Data;
using ErpApi.Data.Common;
using Rhino.Mocks;

namespace ErpApi
{
    [TestClass]
    public class DefaultPrivilegeCollectionTest
    {
        private IDaoFactory factory;

        [TestInitialize]
        public void TestInitialize()
        {
            this.factory = new CommonDaoFactory();
        }

        [TestMethod]
        public void User_id_2733_url_test_aspx()
        {
            var user = MockRepository.GenerateStub<IUser>();
            user
                .Stub(o => o.Id)
                .Return(2733);

            IPrivilegeCollection target = new DefaultPrivilegeCollection(this.factory, user);

            var privilege = target.Find("/test.aspx");
            Assert.IsNotNull(privilege);

            var authority = privilege.Authority;
            Assert.IsNotNull(authority);

            Assert.IsTrue(authority.CanSelect);
            Assert.IsTrue(authority.CanInsert);
            Assert.IsTrue(authority.CanUpdate);
            Assert.IsTrue(authority.CanDelete);
            Assert.IsTrue(authority.CanParticular);
        }
    }
}

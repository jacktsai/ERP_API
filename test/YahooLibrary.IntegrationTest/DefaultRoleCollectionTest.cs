using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Yahoo.Data;
using Yahoo.Data.Common;

namespace Yahoo
{
    [TestClass]
    public class DefaultRoleCollectionTest
    {
        private IDaoFactory factory;

        [TestInitialize]
        public void TestInitialize()
        {
            this.factory = new CommonDaoFactory();
        }

        [TestMethod]
        public void GetRoles_userId_2733()
        {
            var user = MockRepository.GenerateStub<IUser>();
            user
                .Stub(o => o.Id)
                .Return(2733);

            IRoleCollection target = new DefaultRoleCollection(this.factory, user);
            var actual = target.ToArray();

            Assert.AreEqual(5, actual.Length);
            Assert.IsTrue(target.HasSelect);
            Assert.IsTrue(target.HasInsert);
            Assert.IsTrue(target.HasUpdate);
            Assert.IsTrue(target.HasDelete);
            Assert.IsTrue(target.HasParticular);
        }
    }
}

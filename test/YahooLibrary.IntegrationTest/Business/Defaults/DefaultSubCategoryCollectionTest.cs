﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace Yahoo.Business.Defaults
{
    [TestClass]
    public class DefaultSubCategoryCollectionTest
    {
        private IBusinessFactory factory;

        [TestInitialize]
        public void TestInitialize()
        {
            this.factory = new DefaultBusinessFactory();
        }

        [TestMethod]
        public void GetCatPrivileges_userId_2733()
        {
            var user = MockRepository.GenerateStub<IUser>();
            user
                .Stub(o => o.Id)
                .Return(2733);

            ISubCategoryCollection target = new DefaultSubCategoryCollection(this.factory, user);
            var actual = target.ToArray();

            Assert.AreEqual(2, actual.Length);
            Assert.AreEqual(25, actual[0].Id);
            Assert.AreEqual(39, actual[1].Id);
        }
    }
}

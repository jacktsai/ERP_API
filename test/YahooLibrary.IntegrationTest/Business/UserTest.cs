using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Yahoo.DataAccess;

namespace Yahoo.Business
{
    [TestClass]
    public class UserTest
    {
        [TestMethod]
        public void Load_userId_2733()
        {
            var userDao = MockRepository.GenerateStub<IUserDao>();
            userDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything))
                .Return(new UserData
                {
                    Id = 2733,
                    Name = "jacktsai",
                    FullName = "Jack Tsai",
                });

            var factory = MockRepository.GenerateStub<IBusinessFactory>();
            factory
                .Stub(o => o.GetUserDao())
                .Return(userDao);

            var target = new User(factory);
            var success = target.TryLoad(2733);

            Assert.IsTrue(success);
            Assert.AreEqual("jacktsai", target.Name);
            Assert.AreEqual("Jack Tsai", target.FullName);
        }
    }
}

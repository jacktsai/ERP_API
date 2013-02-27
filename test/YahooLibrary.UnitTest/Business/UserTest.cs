using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Yahoo.DataAccess;
using Yahoo.Business.Security.Cryptography;
using Yahoo.Business.Security;

namespace Yahoo.Business
{
    [TestClass]
    public class UserTest
    {
        private IUserDao userDao;
        private IAuthorityDao authorityDao;
        private IUser target;

        [TestInitialize]
        public void TestInitialize()
        {
            userDao = MockRepository.GenerateStub<IUserDao>();
            authorityDao = MockRepository.GenerateStub<IAuthorityDao>();

            var factory = MockRepository.GenerateStub<IBusinessFactory>();
            factory
                .Stub(o => o.GetUserDao())
                .Return(userDao);
            factory
                .Stub(o => o.GetAuthorityDao())
                .Return(authorityDao);

            target = new User(factory);
        }

        [TestMethod]
        public void Load_userId_2733()
        {
            userDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything))
                .Return(new UserData
                {
                    Id = 2733,
                    Name = "jacktsai",
                    FullName = "Jack Tsai",
                });

            var success = target.TryLoad(2733);

            Assert.IsTrue(success);
            Assert.AreEqual(2733, target.Id);
            Assert.AreEqual("jacktsai", target.Name);
            Assert.AreEqual("Jack Tsai", target.FullName);
        }

        [TestMethod]
        public void GetAuthorities()
        {
            userDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything))
                .Return(new UserData { Id = 2733 });

            authorityDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything))
                .Return(new AuthorityData[]
                {
                    new AuthorityData { SystemId = 1, SystemName = "1", CategoryId = 11, CategoryName = "11", SubCategoryId = 111, SubCategoryName = "111", Url = "url1" }
                });

            var success = target.TryLoad(1);
            Assert.AreEqual(2733, target.Id);

            var authorities = target.Authorities.ToArray();
            Assert.AreEqual(1, authorities.Length);
            Assert.AreEqual(1, authorities[0].SystemId);
            Assert.AreEqual("1", authorities[0].SystemName);
            Assert.AreEqual(11, authorities[0].CategoryId);
            Assert.AreEqual("11", authorities[0].CategoryName);
            Assert.AreEqual(111, authorities[0].SubCategoryId);
            Assert.AreEqual("111", authorities[0].SubCategoryName);
            Assert.AreEqual("url1", authorities[0].Url);
        }
    }
}

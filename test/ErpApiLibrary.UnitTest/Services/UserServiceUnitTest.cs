using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpApi.Data;
using Rhino.Mocks;

namespace ErpApi.Services
{
    [TestClass]
    public class UserServiceUnitTest
    {
        private IUserDao _userDao;
        private ISubCategoryDao _subCatDao;
        private IDaoFactory _factory;

        [TestInitialize]
        public void TestInitialize()
        {
            this._userDao = MockRepository.GenerateStub<IUserDao>();

            this._subCatDao = MockRepository.GenerateStub<ISubCategoryDao>();

            this._factory = MockRepository.GenerateStub<IDaoFactory>();
            this._factory
                .Stub(o => o.GetUserDao())
                .Return(this._userDao);
            this._factory
                .Stub(o => o.GetSubCategoryDao())
                .Return(this._subCatDao);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_factory_null()
        {
            new UserService(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetProfile_backyardId_null()
        {
            IUserService target = new UserService(this._factory);
            target.GetProfile(null);
        }

        [TestMethod]
        public void GetProfile_NotExists()
        {
            this._userDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything))
                .Return(null);

            IUserService target = new UserService(this._factory);
            var actual = target.GetProfile("jacktsai");

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetProfile()
        {
            var expectedUser = new UserData
            {
                Id = 2733,
                Name = "jack",
                FullName = "Jack Tsai",
                Department = "department",
                Degree = 1,
                Email = "my email",
                Homepage = "homepage",
                ExtNumber = "12345",
                BackyardId = "jacktsai",
            };
            this._userDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything))
                .Return(expectedUser);

            var expectedSubCat = new SubCategoryData
            {
                Id = 999,
            };
            this._subCatDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything))
                .Return(new SubCategoryData[] { expectedSubCat });

            IUserService target = new UserService(this._factory);
            var actual = target.GetProfile("jacktsai");

            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.User);
            Assert.AreEqual(expectedUser.Id, actual.User.Id);
            Assert.AreEqual(expectedUser.Name, actual.User.Name);
            Assert.AreEqual(expectedUser.FullName, actual.User.FullName);
            Assert.AreEqual(expectedUser.Department, actual.User.Department);
            Assert.AreEqual(expectedUser.Degree, actual.User.Degree);
            Assert.AreEqual(expectedUser.Email, actual.User.Email);
            Assert.AreEqual(expectedUser.Homepage, actual.User.Homepage);
            Assert.AreEqual(expectedUser.ExtNumber, actual.User.ExtNumber);
            Assert.AreEqual(expectedUser.BackyardId, actual.User.BackyardId);
            Assert.IsNotNull(actual.SubCatIds);
            Assert.AreEqual(1, actual.SubCatIds.Count());
            Assert.AreEqual(999, actual.SubCatIds.ElementAt(0));
        }
    }
}

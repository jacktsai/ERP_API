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
        private IDaoFactory _factory;
        private IUserDao _userDao;
        private ISubCategoryDao _subCatDao;
        private IRoleDao _roleDao;
        private IPrivilegeDao _privDao;
        private IDenyPrivilegeDao _denyDao;

        [TestInitialize]
        public void TestInitialize()
        {
            this._factory = MockRepository.GenerateStub<IDaoFactory>();
            this._userDao = MockRepository.GenerateStub<IUserDao>();
            this._subCatDao = MockRepository.GenerateStub<ISubCategoryDao>();
            this._roleDao = MockRepository.GenerateStub<IRoleDao>();
            this._privDao = MockRepository.GenerateStub<IPrivilegeDao>();
            this._denyDao = MockRepository.GenerateStub<IDenyPrivilegeDao>();

            this._factory
                .Stub(o => o.GetUserDao())
                .Return(this._userDao);
            this._factory
                .Stub(o => o.GetSubCategoryDao())
                .Return(this._subCatDao);
            this._factory
                .Stub(o => o.GetRoleDao())
                .Return(this._roleDao);
            this._factory
                .Stub(o => o.GetPrivilegeDao())
                .Return(this._privDao);
            this._factory
                .Stub(o => o.GetDenyPrivilegeDao())
                .Return(this._denyDao);
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

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAuthority_backyardId_null_url_null()
        {
            IUserService target = new UserService(this._factory);
            target.GetAuthority(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAuthority_backyardId_empty_url_null()
        {
            IUserService target = new UserService(this._factory);
            target.GetAuthority(string.Empty, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAuthority_backyardId_null_url_empty()
        {
            IUserService target = new UserService(this._factory);
            target.GetAuthority(null, string.Empty);
        }

        [TestMethod]
        public void GetAuthority_NoPrivilege()
        {
            this._privDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(null);

            IUserService target = new UserService(this._factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanAccess);
            Assert.IsFalse(actual.CanSelect);
            Assert.IsFalse(actual.CanInsert);
            Assert.IsFalse(actual.CanUpdate);
            Assert.IsFalse(actual.CanDelete);
            Assert.IsFalse(actual.CanParticular);
        }

        [TestMethod]
        public void GetAuthority_NoRoles_NoDeny()
        {
            this._privDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new PrivilegeData());

            IUserService target = new UserService(this._factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.CanAccess);
            Assert.IsFalse(actual.CanSelect);
            Assert.IsFalse(actual.CanInsert);
            Assert.IsFalse(actual.CanUpdate);
            Assert.IsFalse(actual.CanDelete);
            Assert.IsFalse(actual.CanParticular);
        }

        [TestMethod]
        public void GetAuthority_Can_true_NoDeny()
        {
            this._privDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new PrivilegeData());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoleDatas(true));

            IUserService target = new UserService(this._factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.CanSelect);
            Assert.IsTrue(actual.CanInsert);
            Assert.IsTrue(actual.CanUpdate);
            Assert.IsTrue(actual.CanDelete);
            Assert.IsTrue(actual.CanParticular);
        }

        [TestMethod]
        public void GetAuthority_Can_false_NoDeny()
        {
            this._privDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new PrivilegeData());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoleDatas(false));

            IUserService target = new UserService(this._factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanSelect);
            Assert.IsFalse(actual.CanInsert);
            Assert.IsFalse(actual.CanUpdate);
            Assert.IsFalse(actual.CanDelete);
            Assert.IsFalse(actual.CanParticular);
        }

        [TestMethod]
        public void GetAuthority_Can_null_NoDeny()
        {
            this._privDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new PrivilegeData());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoleDatas(null));

            IUserService target = new UserService(this._factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanSelect);
            Assert.IsFalse(actual.CanInsert);
            Assert.IsFalse(actual.CanUpdate);
            Assert.IsFalse(actual.CanDelete);
            Assert.IsFalse(actual.CanParticular);
        }

        [TestMethod]
        public void GetAuthority_NoRoles_Deny_true()
        {
            this._privDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new PrivilegeData());
            this._denyDao
                 .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                 .Return(CreateDenyData(true));

            IUserService target = new UserService(this._factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanSelect);
            Assert.IsFalse(actual.CanInsert);
            Assert.IsFalse(actual.CanUpdate);
            Assert.IsFalse(actual.CanDelete);
            Assert.IsFalse(actual.CanParticular);
        }

        [TestMethod]
        public void GetAuthority_NoRoles_Deny_false()
        {
            this._privDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new PrivilegeData());
            this._denyDao
                 .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                 .Return(CreateDenyData(false));

            IUserService target = new UserService(this._factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanSelect);
            Assert.IsFalse(actual.CanInsert);
            Assert.IsFalse(actual.CanUpdate);
            Assert.IsFalse(actual.CanDelete);
            Assert.IsFalse(actual.CanParticular);
        }

        [TestMethod]
        public void GetAuthority_Can_true_Deny_true()
        {
            this._privDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new PrivilegeData());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoleDatas(true));
            this._denyDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateDenyData(true));

            IUserService target = new UserService(this._factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanSelect);
            Assert.IsFalse(actual.CanInsert);
            Assert.IsFalse(actual.CanUpdate);
            Assert.IsFalse(actual.CanDelete);
            Assert.IsFalse(actual.CanParticular);
        }

        [TestMethod]
        public void GetAuthority_Can_true_Deny_false()
        {
            this._privDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new PrivilegeData());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoleDatas(true));
            this._denyDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateDenyData(false));

            IUserService target = new UserService(this._factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.CanSelect);
            Assert.IsTrue(actual.CanInsert);
            Assert.IsTrue(actual.CanUpdate);
            Assert.IsTrue(actual.CanDelete);
            Assert.IsTrue(actual.CanParticular);
        }

        [TestMethod]
        public void GetAuthority_Can_false_Deny_true()
        {
            this._privDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new PrivilegeData());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoleDatas(false));
            this._denyDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateDenyData(true));

            IUserService target = new UserService(this._factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanSelect);
            Assert.IsFalse(actual.CanInsert);
            Assert.IsFalse(actual.CanUpdate);
            Assert.IsFalse(actual.CanDelete);
            Assert.IsFalse(actual.CanParticular);
        }

        [TestMethod]
        public void GetAuthority_Can_false_Deny_false()
        {
            this._privDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new PrivilegeData());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoleDatas(false));
            this._denyDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateDenyData(false));

            IUserService target = new UserService(this._factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanSelect);
            Assert.IsFalse(actual.CanInsert);
            Assert.IsFalse(actual.CanUpdate);
            Assert.IsFalse(actual.CanDelete);
            Assert.IsFalse(actual.CanParticular);
        }

        [TestMethod]
        public void GetAuthority_Can_null_Deny_true()
        {
            this._privDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new PrivilegeData());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoleDatas(null));
            this._denyDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateDenyData(true));

            IUserService target = new UserService(this._factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanSelect);
            Assert.IsFalse(actual.CanInsert);
            Assert.IsFalse(actual.CanUpdate);
            Assert.IsFalse(actual.CanDelete);
            Assert.IsFalse(actual.CanParticular);
        }

        [TestMethod]
        public void GetAuthority_Can_null_Deny_false()
        {
            this._privDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new PrivilegeData());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoleDatas(null));
            this._denyDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateDenyData(false));

            IUserService target = new UserService(this._factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanSelect);
            Assert.IsFalse(actual.CanInsert);
            Assert.IsFalse(actual.CanUpdate);
            Assert.IsFalse(actual.CanDelete);
            Assert.IsFalse(actual.CanParticular);
        }

        private IEnumerable<RoleData> CreateRoleDatas(bool? can)
        {
            var roleData = new RoleData
            {
                CanSelect = can,
                CanInsert = can,
                CanUpdate = can,
                CanDelete = can,
                CanParticular = can,
            };

            return new RoleData[] { roleData };
        }

        private DenyPrivilegeData CreateDenyData(bool deny)
        {
            var denyData = new DenyPrivilegeData
            {
                DenySelect = deny,
                DenyInsert = deny,
                DenyUpdate = deny,
                DenyDelete = deny,
                DenyParticular = deny,
            };

            return denyData;
        }
    }
}

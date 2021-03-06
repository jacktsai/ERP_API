﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpApi.DAL;
using Rhino.Mocks;
using ErpApi.Entities;

namespace ErpApi.BLL
{
    [TestClass]
    public class UserServiceUnitTest
    {
        private IPriUserDao _userDao;
        private ICatSubDao _subCatDao;
        private IRoleDao _roleDao;
        private IPrivilegeDao _privDao;
        private IDenyPrivDao _denyDao;
        private IUserService _target;

        [TestInitialize]
        public void TestInitialize()
        {
            this._userDao = MockRepository.GenerateStub<IPriUserDao>();
            this._subCatDao = MockRepository.GenerateStub<ICatSubDao>();
            this._roleDao = MockRepository.GenerateStub<IRoleDao>();
            this._privDao = MockRepository.GenerateStub<IPrivilegeDao>();
            this._denyDao = MockRepository.GenerateStub<IDenyPrivDao>();

            this._target = new UserService
            {
                PriUserDao = this._userDao,
                CatSubDao = this._subCatDao,
                RoleDao = this._roleDao,
                PrivilegeDao = this._privDao,
                DenyPrivDao = this._denyDao,
            };
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetProfile_backyardId_null()
        {
            this._target.GetProfile(null);
        }

        [TestMethod]
        public void GetProfile_NotExists()
        {
            this._userDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything))
                .Return(null);

            var actual = this._target.GetProfile("jacktsai");

            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetProfile()
        {
            var expectedUser = new PriUser
            {
                Id = 2733,
                Name = "jack",
                FullName = "Jack Tsai",
                Department = "department",
                Degree = 1,
                Email = "my email",
                Homepage = "homepage",
                ExtNo = "12345",
                BackyardId = "jacktsai",
            };
            this._userDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything))
                .Return(expectedUser);

            var expectedSubCat = new CatSub
            {
                Id = 999,
            };
            this._subCatDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything))
                .Return(new[] { expectedSubCat });

            var actual = this._target.GetProfile("jacktsai");

            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.User);
            Assert.AreSame(expectedUser, actual.User);
            Assert.IsNotNull(actual.SubCatIds);
            Assert.AreEqual(1, actual.SubCatIds.Count());
            Assert.AreEqual(999, actual.SubCatIds.ElementAt(0));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAuthority_backyardId_null_url_null()
        {
            this._target.GetAuthority(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAuthority_backyardId_empty_url_null()
        {
            this._target.GetAuthority(string.Empty, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAuthority_backyardId_null_url_empty()
        {
            this._target.GetAuthority(null, string.Empty);
        }

        [TestMethod]
        public void GetAuthority_NoPrivilege()
        {
            this._privDao
                .Stub(o => o.GetOne(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(null);

            var actual = this._target.GetAuthority(string.Empty, string.Empty);

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
                .Return(new Privilege());

            var actual = this._target.GetAuthority(string.Empty, string.Empty);

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
                .Return(new Privilege());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoles(true));

            var actual = this._target.GetAuthority(string.Empty, string.Empty);

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
                .Return(new Privilege());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoles(false));

            var actual = this._target.GetAuthority(string.Empty, string.Empty);

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
                .Return(new Privilege());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoles(null));

            var actual = this._target.GetAuthority(string.Empty, string.Empty);

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
                .Return(new Privilege());
            this._denyDao
                 .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                 .Return(CreateDenyData(true));

            var actual = this._target.GetAuthority(string.Empty, string.Empty);

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
                .Return(new Privilege());
            this._denyDao
                 .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                 .Return(CreateDenyData(false));

            var actual = this._target.GetAuthority(string.Empty, string.Empty);

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
                .Return(new Privilege());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoles(true));
            this._denyDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateDenyData(true));

            var actual = this._target.GetAuthority(string.Empty, string.Empty);

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
                .Return(new Privilege());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoles(true));
            this._denyDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateDenyData(false));

            var actual = this._target.GetAuthority(string.Empty, string.Empty);

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
                .Return(new Privilege());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoles(false));
            this._denyDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateDenyData(true));

            var actual = this._target.GetAuthority(string.Empty, string.Empty);

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
                .Return(new Privilege());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoles(false));
            this._denyDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateDenyData(false));

            var actual = this._target.GetAuthority(string.Empty, string.Empty);

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
                .Return(new Privilege());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoles(null));
            this._denyDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateDenyData(true));

            var actual = this._target.GetAuthority(string.Empty, string.Empty);

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
                .Return(new Privilege());
            this._roleDao
                .Stub(o => o.GetMany(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateRoles(null));
            this._denyDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(CreateDenyData(false));

            var actual = this._target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanSelect);
            Assert.IsFalse(actual.CanInsert);
            Assert.IsFalse(actual.CanUpdate);
            Assert.IsFalse(actual.CanDelete);
            Assert.IsFalse(actual.CanParticular);
        }

        private IEnumerable<Role> CreateRoles(bool? can)
        {
            var Role = new Role
            {
                Select = can,
                Insert = can,
                Update = can,
                Delete = can,
                Particular = can,
            };

            return new Role[] { Role };
        }

        private DenyPriv CreateDenyData(bool deny)
        {
            var denyData = new DenyPriv
            {
                Select = deny,
                Insert = deny,
                Update = deny,
                Delete = deny,
                Particular = deny,
            };

            return denyData;
        }
    }
}

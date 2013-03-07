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
    public class AuthorizationServiceTest
    {
        private IAuthorityDao authDao;
        private IDaoFactory factory;

        [TestInitialize]
        public void TestInitialize()
        {
            this.authDao = MockRepository.GenerateStub<IAuthorityDao>();

            this.factory = MockRepository.GenerateStub<IDaoFactory>();
            this.factory
                .Stub(o => o.GetAuthorityDao())
                .Return(this.authDao);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_factory_null()
        {
            new AuthorizationService(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAuthority_backyardId_null_url_null()
        {
            IAuthorizationService target = new AuthorizationService(this.factory);
            target.GetAuthority(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAuthority_backyardId_empty_url_null()
        {
            IAuthorizationService target = new AuthorizationService(this.factory);
            target.GetAuthority(string.Empty, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetAuthority_backyardId_null_url_empty()
        {
            IAuthorizationService target = new AuthorizationService(this.factory);
            target.GetAuthority(null, string.Empty);
        }

        [TestMethod]
        public void GetAuthority_NullReturn()
        {
            this.authDao
                .Stub(o => o.GetMany(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(null);

            IAuthorizationService target = new AuthorizationService(this.factory);
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
        public void GetAuthority_NoAuthority()
        {
            this.authDao
                .Stub(o => o.GetMany(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(new AuthorityData[0]);

            IAuthorizationService target = new AuthorizationService(this.factory);
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
        public void GetAuthority_CanSelect_true_DenySelect_null()
        {
            var datas = new AuthorityData[]
            {
                new AuthorityData { CanSelect = true, DenySelect = null },
            };

            this.authDao
                .Stub(o => o.GetMany(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(datas);

            IAuthorizationService target = new AuthorizationService(this.factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.CanSelect);
        }

        [TestMethod]
        public void GetAuthority_CanSelect_true_DenySelect_false()
        {
            var datas = new AuthorityData[]
            {
                new AuthorityData { CanSelect = true, DenySelect = false },
            };

            this.authDao
                .Stub(o => o.GetMany(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(datas);

            IAuthorizationService target = new AuthorizationService(this.factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.CanSelect);
        }

        [TestMethod]
        public void GetAuthority_CanInsert_true_DenyInsert_true()
        {
            var datas = new AuthorityData[]
            {
                new AuthorityData { CanInsert = true, DenyInsert = true },
            };

            this.authDao
                .Stub(o => o.GetMany(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(datas);

            IAuthorizationService target = new AuthorizationService(this.factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanInsert);
        }

        [TestMethod]
        public void GetAuthority_CanInsert_false_DenyInsert_null()
        {
            var datas = new AuthorityData[]
            {
                new AuthorityData { CanInsert = false, DenyInsert = null },
            };

            this.authDao
                .Stub(o => o.GetMany(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(datas);

            IAuthorizationService target = new AuthorizationService(this.factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanInsert);
        }

        [TestMethod]
        public void GetAuthority_CanUpdate_false_DenyUpdate_false()
        {
            var datas = new AuthorityData[]
            {
                new AuthorityData { CanUpdate = false, DenyUpdate = false },
            };

            this.authDao
                .Stub(o => o.GetMany(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(datas);

            IAuthorizationService target = new AuthorizationService(this.factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanUpdate);
        }

        [TestMethod]
        public void GetAuthority_CanUpdate_false_DenyUpdate_true()
        {
            var datas = new AuthorityData[]
            {
                new AuthorityData { CanUpdate = false, DenyUpdate = true },
            };

            this.authDao
                .Stub(o => o.GetMany(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(datas);

            IAuthorizationService target = new AuthorizationService(this.factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanUpdate);
        }

        [TestMethod]
        public void GetAuthority_CanDelete_null_DenyDelete_null()
        {
            var datas = new AuthorityData[]
            {
                new AuthorityData { CanDelete = null, DenyDelete = null },
            };

            this.authDao
                .Stub(o => o.GetMany(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(datas);

            IAuthorizationService target = new AuthorizationService(this.factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanDelete);
        }

        [TestMethod]
        public void GetAuthority_CanDelete_null_DenyDelete_false()
        {
            var datas = new AuthorityData[]
            {
                new AuthorityData { CanDelete = null, DenyDelete = false },
            };

            this.authDao
                .Stub(o => o.GetMany(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(datas);

            IAuthorizationService target = new AuthorizationService(this.factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanDelete);
        }

        [TestMethod]
        public void GetAuthority_CanParticular_null_DenyParticular_true()
        {
            var datas = new AuthorityData[]
            {
                new AuthorityData { CanParticular = null, DenyParticular = true },
            };

            this.authDao
                .Stub(o => o.GetMany(Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(datas);

            IAuthorizationService target = new AuthorizationService(this.factory);
            var actual = target.GetAuthority(string.Empty, string.Empty);

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanParticular);
        }
    }
}

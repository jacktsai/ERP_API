using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpApi.DAL;

namespace ErpApi.BLL
{
    [TestClass]
    public class UserServiceTest
    {
        private IUserService _target;

        [TestInitialize]
        public void TestInitialize()
        {
            this._target = new UserService()
            {
                PriUserDao = new PriUserDao(),
                CatSubDao = new CatSubDao(),
                RoleDao = new RoleDao(),
                PrivilegeDao = new PrivilegeDao(),
                DenyPrivDao = new DenyPrivDao(),
            };
        }

        [TestMethod]
        public void GetProfile_backyardId_jacktsai()
        {
            var actual = this._target.GetProfile("jacktsai");

            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.User);
            Assert.AreEqual(2733, actual.User.Id);
            Assert.AreEqual("jacktsai", actual.User.Name);
            Assert.AreEqual("Jack Tsai", actual.User.FullName);
            Assert.AreEqual("研發", actual.User.Department);
            Assert.AreEqual(0, actual.User.Degree);
            Assert.AreEqual("/privilege/homepages/erp.asp", actual.User.Homepage);
            Assert.AreEqual("3628", actual.User.ExtNo);
            Assert.AreEqual("jacktsai", actual.User.BackyardId);
            Assert.IsNotNull(actual.SubCatIds);
            Assert.AreEqual(2, actual.SubCatIds.Count());
            Assert.AreEqual(25, actual.SubCatIds.ElementAt(0));
            Assert.AreEqual(39, actual.SubCatIds.ElementAt(1));
        }

        [TestMethod]
        public void GetProfile_backyardId_kevin113()
        {
            var actual = this._target.GetProfile("kevin113");

            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.User);
            Assert.AreEqual(2121, actual.User.Id);
            Assert.AreEqual("kevincheng", actual.User.Name);
            Assert.AreEqual("鄭凱文", actual.User.FullName);
            Assert.AreEqual("研發", actual.User.Department);
            Assert.AreEqual(0, actual.User.Degree);
            Assert.AreEqual("/privilege/homepages/ERP.asp", actual.User.Homepage);
            Assert.AreEqual("151", actual.User.ExtNo);
            Assert.AreEqual("kevin113", actual.User.BackyardId);
            Assert.IsNotNull(actual.SubCatIds);
            Assert.AreEqual(0, actual.SubCatIds.Count());
        }

        [TestMethod]
        public void GetAuthority_backyardId_jacktsai_url_testaspx()
        {
            var actual = this._target.GetAuthority("jacktsai", "/test.aspx");

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.CanAccess);
            Assert.IsFalse(actual.CanSelect);
            Assert.IsFalse(actual.CanInsert);
            Assert.IsFalse(actual.CanUpdate);
            Assert.IsFalse(actual.CanDelete);
            Assert.IsFalse(actual.CanParticular);
        }

        [TestMethod]
        public void GetAuthority_backyardId_jacktsai_url_usermgmtaspx()
        {
            var actual = this._target.GetAuthority("jacktsai", "/Security/Privilege/UserMgmt.aspx");

            Assert.IsNotNull(actual);
            Assert.IsTrue(actual.CanAccess);
            Assert.IsTrue(actual.CanSelect);
            Assert.IsTrue(actual.CanInsert);
            Assert.IsTrue(actual.CanUpdate);
            Assert.IsTrue(actual.CanDelete);
            Assert.IsTrue(actual.CanParticular);
        }

        [TestMethod]
        public void GetAuthority_backyardId_jacktsai_url_NotExists()
        {
            var actual = this._target.GetAuthority("jacktsai", "not_exists.aspx");

            Assert.IsNotNull(actual);
            Assert.IsFalse(actual.CanAccess);
            Assert.IsFalse(actual.CanSelect);
            Assert.IsFalse(actual.CanInsert);
            Assert.IsFalse(actual.CanUpdate);
            Assert.IsFalse(actual.CanDelete);
            Assert.IsFalse(actual.CanParticular);
        }
    }
}

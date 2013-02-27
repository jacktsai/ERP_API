using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahoo.Business.Security.Cryptography;

namespace Yahoo.Business.Security
{
    [TestClass]
    public class DefaultSecurityServiceTest
    {
        private ISecurityService target;

        [TestInitialize]
        public void TestInitialize()
        {
            var userDao = new Yahoo.DataAccess.Common.UserDao();
            var roleDao = new Yahoo.DataAccess.Common.RoleDao();
            var privilegeDao = new Yahoo.DataAccess.Common.PrivilegeDao();
            var functionDao = new Yahoo.DataAccess.Common.FunctionDao();
            var hashProvider = new DefaultHashProvider();

            target = new DefaultSecurityService(userDao, roleDao, privilegeDao, functionDao, hashProvider);
        }

        [TestMethod]
        public void GetUserProfile_userId_2733()
        {
            var actual = target.GetProfile(2733);

            Assert.IsNotNull(actual);
            Assert.AreEqual(2733, actual.Id);
            Assert.AreEqual("jacktsai", actual.Name);
            Assert.AreEqual("Jack Tsai", actual.FullName);
            Assert.AreEqual("研發", actual.Department);
            Assert.AreEqual(0, actual.Degree);
            Assert.AreEqual("/privilege/homepages/erp.asp", actual.Homepage);
            Assert.AreEqual("3628", actual.ExtensionNumber);
            Assert.AreEqual("jacktsai", actual.BackyardId);

            Assert.IsTrue(actual.HasSelect);
            Assert.IsTrue(actual.HasInsert);
            Assert.IsTrue(actual.HasUpdate);
            Assert.IsFalse(actual.HasDelete);
            Assert.IsFalse(actual.HasParticular);

            Assert.IsNotNull(actual.PrivilegeInfos);
            Assert.AreEqual(256, actual.PrivilegeInfos.Length);
        }

        [TestMethod]
        public void GetUserProfile_userId_2121()
        {
            var actual = target.GetProfile(2121);
        }
    }
}

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
    public class DefaultUserTest
    {
        private IBusinessFactory factory;

        [TestInitialize]
        public void TestInitialize()
        {
            this.factory = new DefaultBusinessFactory();
        }

        [TestMethod]
        public void LoadAsync_backyardId_jacktsai()
        {
            IUser target = new DefaultUser(this.factory);
            target.LoadAsync("jacktsai").Wait();

            Assert.AreEqual(2733, target.Id);
            Assert.AreEqual("jacktsai", target.Name);
            Assert.AreEqual("Jack Tsai", target.FullName);
            Assert.AreEqual("研發", target.Department);
            Assert.AreEqual(0, target.Degree);
            Assert.AreEqual("/privilege/homepages/erp.asp", target.Homepage);
            Assert.AreEqual("3628", target.ExtensionNumber);
            Assert.AreEqual("jacktsai", target.BackyardId);
        }

        [TestMethod]
        public void GetRoles_userId_2733()
        {
            IUser target = new DefaultUser(this.factory, userId: 2733);

            var actual = target.Roles.ToArray();
            Assert.AreEqual(5, actual.Length);
            Assert.IsTrue(target.Roles.HasSelect);
            Assert.IsTrue(target.Roles.HasInsert);
            Assert.IsTrue(target.Roles.HasUpdate);
            Assert.IsTrue(target.Roles.HasDelete);
            Assert.IsTrue(target.Roles.HasParticular);
        }

        //[TestMethod]
        //public void GetAuthorities_userId_2733()
        //{
        //    IUser target = new DefaultUser(this.factory, userId: 2733);

        //    var authorities = target.Authorities.ToArray();
        //}

        [TestMethod]
        public void GetCatPrivileges_userId_2733()
        {
            IUser target = new DefaultUser(this.factory, userId: 2733);

            var actual = target.CatPrivileges.ToArray();
            Assert.AreEqual(2, actual.Length);
            Assert.AreEqual(25, actual[0].SubId);
            Assert.AreEqual(39, actual[1].SubId);
        }
    }
}

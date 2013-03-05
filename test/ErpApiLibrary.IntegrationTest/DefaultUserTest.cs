using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using ErpApi.Data;
using ErpApi.Data.Common;

namespace ErpApi
{
    [TestClass]
    public class DefaultUserTest
    {
        private IDaoFactory factory;

        [TestInitialize]
        public void TestInitialize()
        {
            this.factory = new CommonDaoFactory();
        }

        [TestMethod]
        public void LoadAsync_backyardId_jacktsai()
        {
            var target = new DefaultUser(this.factory, backyardId: "jacktsai");
            target.LoadAsync().Wait();

            var actual = target as IUser;

            Assert.AreEqual(2733, actual.Id);
            Assert.AreEqual("jacktsai", actual.Name);
            Assert.AreEqual("Jack Tsai", actual.FullName);
            Assert.AreEqual("研發", actual.Department);
            Assert.AreEqual(0, actual.Degree);
            Assert.AreEqual("/privilege/homepages/erp.asp", actual.Homepage);
            Assert.AreEqual("3628", actual.ExtNumber);
            Assert.AreEqual("jacktsai", actual.BackyardId);
            Assert.AreEqual("25,39", string.Join(",", actual.SubCategories.Select(o => o.Id)));
        }

        [TestMethod]
        public void LoadAsync_backyardId_kevin113()
        {
            var target = new DefaultUser(this.factory, backyardId: "kevin113");
            target.LoadAsync().Wait();

            var actual = target as IUser;

            Assert.AreEqual(2121, actual.Id);
            Assert.AreEqual("kevincheng", actual.Name);
            Assert.AreEqual("鄭凱文", actual.FullName);
            Assert.AreEqual("研發", actual.Department);
            Assert.AreEqual(0, actual.Degree);
            Assert.AreEqual("/privilege/homepages/ERP.asp", actual.Homepage);
            Assert.AreEqual("151", actual.ExtNumber);
            Assert.AreEqual("kevin113", actual.BackyardId);
            Assert.AreEqual("", string.Join(",", actual.SubCategories.Select(o => o.Id)));
        }
    }
}

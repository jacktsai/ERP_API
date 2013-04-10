using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpApi.DAL
{
    [TestClass]
    public class PriUserDaoTest
    {
        [TestMethod]
        public void GetOne_backyardId_jacktsai()
        {
            IPriUserDao target = new PriUserDao();
            var actual = target.GetOne("jacktsai");

            Assert.IsNotNull(actual);
            Assert.AreEqual(2733, actual.Id);
            Assert.AreEqual("jacktsai", actual.Name);
            Assert.AreEqual("Jack Tsai", actual.FullName);
            Assert.AreEqual("雅虎資訊", actual.Company);
            Assert.AreEqual("研發", actual.Department);
            Assert.AreEqual(0, actual.Degree);
            Assert.AreEqual("jacktsai@yahoo-inc.com", actual.Email);
            Assert.AreEqual("/privilege/homepages/erp.asp", actual.Homepage);
            Assert.AreEqual("3628", actual.ExtNo);
            Assert.AreEqual("jacktsai", actual.BackyardId);
        }

        public void GetMany_userName_jacktsai()
        {
            IPriUserDao target = new PriUserDao();
            var actual = target.GetMany(new[] { "jacktsai" });

            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Count());

            var element1 = actual.ElementAt(0);
            Assert.AreEqual(2733, element1.Id);
            Assert.AreEqual("jacktsai", element1.Name);
            Assert.AreEqual("Jack Tsai", element1.FullName);
            Assert.AreEqual("雅虎資訊", element1.Company);
            Assert.AreEqual("研發", element1.Department);
            Assert.AreEqual(0, element1.Degree);
            Assert.AreEqual("jacktsai@yahoo-inc.com", element1.Email);
            Assert.AreEqual("/privilege/homepages/erp.asp", element1.Homepage);
            Assert.AreEqual("3628", element1.ExtNo);
            Assert.AreEqual("jacktsai", element1.BackyardId);
        }
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpApi.DAL
{
    [TestClass]
    public class UserDaoTest
    {
        [TestMethod]
        public void GetOne_backyardId_jacktsai()
        {
            IUserDao target = new UserDao();
            var actual = target.GetOne("jacktsai");

            Assert.IsNotNull(actual);
            Assert.AreEqual(2733, actual.priuser_id);
            Assert.AreEqual("jacktsai", actual.priuser_name);
            Assert.AreEqual("Jack Tsai", actual.priuser_fullname);
            Assert.AreEqual("雅虎資訊", actual.priuser_company);
            Assert.AreEqual("研發", actual.priuser_department);
            Assert.AreEqual(0, actual.priuser_degree);
            Assert.AreEqual("jacktsai@yahoo-inc.com", actual.priuser_email);
            Assert.AreEqual("/privilege/homepages/erp.asp", actual.priuser_homepage);
            Assert.AreEqual("3628", actual.priuser_extno);
            Assert.AreEqual("jacktsai", actual.priuser_backyardid);
        }

        public void GetMany_userName_jacktsai()
        {
            IUserDao target = new UserDao();
            var actual = target.GetMany(new[] { "jacktsai" });

            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Count());

            var element1 = actual.ElementAt(0);
            Assert.AreEqual(2733, element1.priuser_id);
            Assert.AreEqual("jacktsai", element1.priuser_name);
            Assert.AreEqual("Jack Tsai", element1.priuser_fullname);
            Assert.AreEqual("雅虎資訊", element1.priuser_company);
            Assert.AreEqual("研發", element1.priuser_department);
            Assert.AreEqual(0, element1.priuser_degree);
            Assert.AreEqual("jacktsai@yahoo-inc.com", element1.priuser_email);
            Assert.AreEqual("/privilege/homepages/erp.asp", element1.priuser_homepage);
            Assert.AreEqual("3628", element1.priuser_extno);
            Assert.AreEqual("jacktsai", element1.priuser_backyardid);
        }
    }
}

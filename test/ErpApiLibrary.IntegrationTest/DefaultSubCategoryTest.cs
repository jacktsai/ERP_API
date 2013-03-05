using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpApi.Data;
using ErpApi.Data.Common;

namespace ErpApi
{
    [TestClass]
    public class DefaultSubCategoryTest
    {
        private IDaoFactory factory;

        [TestInitialize]
        public void TestInitialize()
        {
            this.factory = new CommonDaoFactory();
        }

        [TestMethod]
        public void GetUser_id_2_User()
        {
            ISubCategory target = new DefaultSubCategory(this.factory, 2);
            var actual = target.User;

            Assert.IsNotNull(actual);
            Assert.AreEqual("joannali", actual.BackyardId);
            Assert.AreEqual("李瑞君", actual.FullName);
            Assert.AreEqual("333", actual.ExtNumber);
            Assert.AreEqual("joannali@yahoo-inc.com", actual.Email);
        }

        [TestMethod]
        public void GetUser_id_3_Manager()
        {
            ISubCategory target = new DefaultSubCategory(this.factory, 3);
            var actual = target.Manager;

            Assert.IsNotNull(actual);
            Assert.AreEqual("juliachen", actual.BackyardId);
            Assert.AreEqual("茱莉亞", actual.FullName);
            Assert.AreEqual("123456", actual.ExtNumber);
            Assert.AreEqual("juliachen@yahoo-inc.com", actual.Email);
        }

        [TestMethod]
        public void GetUser_id_4_Purchaser()
        {
            ISubCategory target = new DefaultSubCategory(this.factory, 4);
            var actual = target.Purchaser;

            Assert.IsNotNull(actual);
            Assert.AreEqual("coco0208", actual.BackyardId);
            Assert.AreEqual("楊雅馨", actual.FullName);
            Assert.AreEqual("770", actual.ExtNumber);
            Assert.AreEqual("coco0208@yahoo-inc.com", actual.Email);
        }

        [TestMethod]
        public void GetUser_id_5_Staff()
        {
            ISubCategory target = new DefaultSubCategory(this.factory, 5);
            var actual = target.Staff;

            Assert.IsNotNull(actual);
            Assert.AreEqual("cindytu", actual.BackyardId);
            Assert.AreEqual("杜欣怡", actual.FullName);
            Assert.AreEqual("777", actual.ExtNumber);
            Assert.AreEqual("cindytu@yahoo-inc.com", actual.Email);
        }
    }
}

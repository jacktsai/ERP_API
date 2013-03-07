using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpApi.Data.Common;
using ErpApi.Data;

namespace ErpApi.Services
{
    [TestClass]
    public class SubCategoryServiceTest
    {
        private readonly IDaoFactory _factory = new CommonDaoFactory();

        [TestMethod]
        public void GetSubCategories_subCategoryIds_2_3_4_5()
        {
            var subCategoryIds = new int[] { 2, 3, 4, 5 };

            ISubCategoryService target = new SubCategoryService(this._factory);
            var actual = target.GetSubCategoryUsers(subCategoryIds);

            Assert.IsNotNull(actual);
            Assert.AreEqual(4, actual.Count());

            var subCat1 = actual.ElementAt(0);
            Assert.IsNotNull(subCat1);
            Assert.AreEqual(2, subCat1.Id);
            Assert.IsNotNull(subCat1.Pm);
            Assert.AreEqual("joannali", subCat1.Pm.BackyardId);
            Assert.AreEqual("李瑞君", subCat1.Pm.FullName);
            Assert.AreEqual("333", subCat1.Pm.ExtNumber);
            Assert.AreEqual("joannali@yahoo-inc.com", subCat1.Pm.Email);

            var subCat2 = actual.ElementAt(1);
            Assert.IsNotNull(subCat2);
            Assert.AreEqual(3, subCat2.Id);
            Assert.IsNotNull(subCat2.Manager);
            Assert.AreEqual("juliachen", subCat2.Manager.BackyardId);
            Assert.AreEqual("茱莉亞", subCat2.Manager.FullName);
            Assert.AreEqual("123456", subCat2.Manager.ExtNumber);
            Assert.AreEqual("juliachen@yahoo-inc.com", subCat2.Manager.Email);

            var subCat3 = actual.ElementAt(2);
            Assert.IsNotNull(subCat3);
            Assert.AreEqual(4, subCat3.Id);
            Assert.IsNotNull(subCat3.Purchaser);
            Assert.AreEqual("coco0208", subCat3.Purchaser.BackyardId);
            Assert.AreEqual("楊雅馨", subCat3.Purchaser.FullName);
            Assert.AreEqual("770", subCat3.Purchaser.ExtNumber);
            Assert.AreEqual("coco0208@yahoo-inc.com", subCat3.Purchaser.Email);

            var subCat4 = actual.ElementAt(3);
            Assert.IsNotNull(subCat4);
            Assert.AreEqual(5, subCat4.Id);
            Assert.IsNotNull(subCat4.Staff);
            Assert.AreEqual("cindytu", subCat4.Staff.BackyardId);
            Assert.AreEqual("杜欣怡", subCat4.Staff.FullName);
            Assert.AreEqual("777", subCat4.Staff.ExtNumber);
            Assert.AreEqual("cindytu@yahoo-inc.com", subCat4.Staff.Email);
        }
    }
}

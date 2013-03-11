using System.Linq;
using ErpApi.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpApi.BLL
{
    [TestClass]
    public class SubCategoryServiceTest
    {
        private ISubCategoryService _target;

        [TestInitialize]
        public void TestInitialize()
        {
            this._target = new SubCategoryService()
            {
                UserDao = new UserDao(),
                SubCategoryDao = new SubCategoryDao(),
            };
        }

        [TestMethod]
        public void GetSubCategories_subCategoryIds_2_3_4_5()
        {
            var subCategoryIds = new int[] { 2, 3, 4, 5 };

            var actual = this._target.GetSubCategoryUsers(subCategoryIds);

            Assert.IsNotNull(actual);
            Assert.AreEqual(4, actual.Count());

            var subCat1 = actual.ElementAt(0);
            Assert.IsNotNull(subCat1);
            Assert.AreEqual(2, subCat1.Id);
            Assert.IsNotNull(subCat1.Pm);
            Assert.AreEqual("joannali", subCat1.Pm.priuser_backyardid);
            Assert.AreEqual("李瑞君", subCat1.Pm.priuser_fullname);
            Assert.AreEqual("333", subCat1.Pm.priuser_extno);
            Assert.AreEqual("joannali@yahoo-inc.com", subCat1.Pm.priuser_email);

            var subCat2 = actual.ElementAt(1);
            Assert.IsNotNull(subCat2);
            Assert.AreEqual(3, subCat2.Id);
            Assert.IsNotNull(subCat2.Manager);
            Assert.AreEqual("juliachen", subCat2.Manager.priuser_backyardid);
            Assert.AreEqual("茱莉亞", subCat2.Manager.priuser_fullname);
            Assert.AreEqual("123456", subCat2.Manager.priuser_extno);
            Assert.AreEqual("juliachen@yahoo-inc.com", subCat2.Manager.priuser_email);

            var subCat3 = actual.ElementAt(2);
            Assert.IsNotNull(subCat3);
            Assert.AreEqual(4, subCat3.Id);
            Assert.IsNotNull(subCat3.Purchaser);
            Assert.AreEqual("coco0208", subCat3.Purchaser.priuser_backyardid);
            Assert.AreEqual("楊雅馨", subCat3.Purchaser.priuser_fullname);
            Assert.AreEqual("770", subCat3.Purchaser.priuser_extno);
            Assert.AreEqual("coco0208@yahoo-inc.com", subCat3.Purchaser.priuser_email);

            var subCat4 = actual.ElementAt(3);
            Assert.IsNotNull(subCat4);
            Assert.AreEqual(5, subCat4.Id);
            Assert.IsNotNull(subCat4.Staff);
            Assert.AreEqual("cindytu", subCat4.Staff.priuser_backyardid);
            Assert.AreEqual("杜欣怡", subCat4.Staff.priuser_fullname);
            Assert.AreEqual("777", subCat4.Staff.priuser_extno);
            Assert.AreEqual("cindytu@yahoo-inc.com", subCat4.Staff.priuser_email);
        }
    }
}
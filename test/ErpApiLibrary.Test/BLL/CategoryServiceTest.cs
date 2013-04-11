using System.Linq;
using ErpApi.DAL;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpApi.BLL
{
    [TestClass]
    public class CategoryServiceTest
    {
        private ICategoryService _target;

        [TestInitialize]
        public void TestInitialize()
        {
            this._target = new CategoryService()
            {
                PriUserDao = new PriUserDao(),
                CatSubDao = new CatSubDao(),
                CatZoneDao = new CatZoneDao(),
            };
        }

        [TestMethod]
        public void GetCategoryContacts_categoryIds_2_3_4_5()
        {
            var subCategoryIds = new int[] { 2, 3, 4, 5 };

            var actual = this._target.GetCategoryContacts(subCategoryIds);

            Assert.IsNotNull(actual);
            Assert.AreEqual(4, actual.Count());

            var subCat1 = actual.ElementAt(0);
            Assert.IsNotNull(subCat1);
            Assert.AreEqual(2, subCat1.Id);
            Assert.IsNotNull(subCat1.Pm);
            Assert.AreEqual("joannali", subCat1.Pm.BackyardId);
            Assert.AreEqual("李瑞君", subCat1.Pm.FullName);
            Assert.AreEqual("333", subCat1.Pm.ExtNo);
            Assert.AreEqual("joannali@yahoo-inc.com", subCat1.Pm.Email);

            var subCat2 = actual.ElementAt(1);
            Assert.IsNotNull(subCat2);
            Assert.AreEqual(3, subCat2.Id);
            Assert.IsNotNull(subCat2.Manager);
            Assert.AreEqual("juliachen", subCat2.Manager.BackyardId);
            Assert.AreEqual("茱莉亞", subCat2.Manager.FullName);
            Assert.AreEqual("123456", subCat2.Manager.ExtNo);
            Assert.AreEqual("juliachen@yahoo-inc.com", subCat2.Manager.Email);

            var subCat3 = actual.ElementAt(2);
            Assert.IsNotNull(subCat3);
            Assert.AreEqual(4, subCat3.Id);
            Assert.IsNotNull(subCat3.Purchaser);
            Assert.AreEqual("coco0208", subCat3.Purchaser.BackyardId);
            Assert.AreEqual("楊雅馨", subCat3.Purchaser.FullName);
            Assert.AreEqual("770", subCat3.Purchaser.ExtNo);
            Assert.AreEqual("coco0208@yahoo-inc.com", subCat3.Purchaser.Email);

            var subCat4 = actual.ElementAt(3);
            Assert.IsNotNull(subCat4);
            Assert.AreEqual(5, subCat4.Id);
            Assert.IsNotNull(subCat4.Staff);
            Assert.AreEqual("cindytu", subCat4.Staff.BackyardId);
            Assert.AreEqual("杜欣怡", subCat4.Staff.FullName);
            Assert.AreEqual("777", subCat4.Staff.ExtNo);
            Assert.AreEqual("cindytu@yahoo-inc.com", subCat4.Staff.Email);
        }

        [TestMethod]
        public void GetCategories_categoryIds_1_2_3_4_5()
        {
            var actual = this._target.GetCategories(new[] { 1, 2, 3, 4, 5 });

            Assert.IsNotNull(actual);
            Assert.AreEqual(5, actual.Count());

            var model1 = actual.Single(o => o.CatSub.Id == 1);
            Assert.AreEqual(1, model1.CatSub.Id);
            Assert.AreEqual("筆記型電腦超過十一個字test", model1.CatSub.Name);

            var model2 = actual.Single(o => o.CatSub.Id == 2);
            Assert.AreEqual(2, model2.CatSub.Id);
            Assert.AreEqual("數位相機1", model2.CatSub.Name);

            var model3 = actual.Single(o => o.CatSub.Id == 3);
            Assert.AreEqual(3, model3.CatSub.Id);
            Assert.AreEqual("AV器材(暫隱形)", model3.CatSub.Name);

            var model4 = actual.Single(o => o.CatSub.Id == 4);
            Assert.AreEqual(4, model4.CatSub.Id);
            Assert.AreEqual("流行包", model4.CatSub.Name);

            var model5 = actual.Single(o => o.CatSub.Id == 5);
            Assert.AreEqual(5, model5.CatSub.Id);
            Assert.AreEqual("寢具、棉被、床包", model5.CatSub.Name);
        }
    }
}
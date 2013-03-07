using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpApi.Data;
using Rhino.Mocks;

namespace ErpApi.Services
{
    [TestClass]
    public class SubCategoryServiceUnitTest
    {
        private ISubCategoryDao _subCatDao;
        private IUserDao _userDao;
        private IDaoFactory _factory;

        [TestInitialize]
        public void TestInitialize()
        {
            this._subCatDao = MockRepository.GenerateStub<ISubCategoryDao>();
            this._userDao = MockRepository.GenerateStub<IUserDao>();

            this._factory = MockRepository.GenerateStub<IDaoFactory>();
            this._factory
                .Stub(o => o.GetSubCategoryDao())
                .Return(this._subCatDao);
            this._factory
                .Stub(o => o.GetUserDao())
                .Return(this._userDao);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_factory_null()
        {
            new SubCategoryService(null);
        }

        [TestMethod]
        public void GetSubCategories_SubCatData_null()
        {
            this._subCatDao
                .Stub(o => o.GetMany(Arg<IEnumerable<int>>.Is.Anything))
                .Return(null);

            ISubCategoryService target = new SubCategoryService(this._factory);
            var actual = target.GetSubCategoryUsers(new[] { 1 });

            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count());
        }

        [TestMethod]
        public void GetSubCategories_SubCatData_ZeroLength()
        {
            this._subCatDao
                .Stub(o => o.GetMany(Arg<IEnumerable<int>>.Is.Anything))
                .Return(new SubCategoryData[0]);

            ISubCategoryService target = new SubCategoryService(this._factory);
            var actual = target.GetSubCategoryUsers(new[] { 1 });

            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count());
        }

        [TestMethod]
        public void GetSubCategories_UserData_null()
        {
            var subCatData1 = new SubCategoryData
            {
                Id = 1,
                PmName = "pm name",
                ManagerName = "manager name",
                PurchaserName = "",
                StaffName = null,
            };
            var subCatData2 = new SubCategoryData
            {
                Id = 3,
                PmName = null,
                ManagerName = string.Empty,
                PurchaserName = "purchaser name",
                StaffName = "staff name",
            };
            this._subCatDao
                .Stub(o => o.GetMany(Arg<IEnumerable<int>>.Is.Anything))
                .Return(new[] { subCatData1, subCatData2 });

            this._userDao
                .Stub(o => o.GetMany(Arg<IEnumerable<string>>.Is.Anything))
                .Return(null);

            ISubCategoryService target = new SubCategoryService(this._factory);
            var subCats = target.GetSubCategoryUsers(new[] { 1, 2, 3 });

            Assert.IsNotNull(subCats);
            Assert.AreEqual(2, subCats.Count());

            var subCat1 = subCats.ElementAt(0);
            Assert.AreEqual(1, subCat1.Id);
            Assert.IsNull(subCat1.Pm);
            Assert.IsNull(subCat1.Manager);
            Assert.IsNull(subCat1.Purchaser);
            Assert.IsNull(subCat1.Staff);

            var subCat2 = subCats.ElementAt(1);
            Assert.AreEqual(3, subCat2.Id);
            Assert.IsNull(subCat2.Pm);
            Assert.IsNull(subCat2.Manager);
            Assert.IsNull(subCat2.Purchaser);
            Assert.IsNull(subCat2.Staff);
        }

        [TestMethod]
        public void GetSubCategories_UserData_ZeroLength()
        {
            var subCatData1 = new SubCategoryData
            {
                Id = 1,
                PmName = "pm name",
                ManagerName = "manager name",
                PurchaserName = "",
                StaffName = null,
            };
            var subCatData2 = new SubCategoryData
            {
                Id = 3,
                PmName = null,
                ManagerName = string.Empty,
                PurchaserName = "purchaser name",
                StaffName = "staff name",
            };
            this._subCatDao
                .Stub(o => o.GetMany(Arg<IEnumerable<int>>.Is.Anything))
                .Return(new[] { subCatData1, subCatData2 });

            this._userDao
                .Stub(o => o.GetMany(Arg<IEnumerable<string>>.Is.Anything))
                .Return(new UserData[0]);

            ISubCategoryService target = new SubCategoryService(this._factory);
            var subCats = target.GetSubCategoryUsers(new[] { 1, 2, 3 });

            Assert.IsNotNull(subCats);
            Assert.AreEqual(2, subCats.Count());

            var subCat1 = subCats.ElementAt(0);
            Assert.AreEqual(1, subCat1.Id);
            Assert.IsNull(subCat1.Pm);
            Assert.IsNull(subCat1.Manager);
            Assert.IsNull(subCat1.Purchaser);
            Assert.IsNull(subCat1.Staff);

            var subCat2 = subCats.ElementAt(1);
            Assert.AreEqual(3, subCat2.Id);
            Assert.IsNull(subCat2.Pm);
            Assert.IsNull(subCat2.Manager);
            Assert.IsNull(subCat2.Purchaser);
            Assert.IsNull(subCat2.Staff);
        }

        [TestMethod]
        public void GetSubCategories()
        {
            var subCatData1 = new SubCategoryData
            {
                Id = 1,
                PmName = "pm name",
                ManagerName = "manager name",
                PurchaserName = "",
                StaffName = null,
            };
            var subCatData2 = new SubCategoryData
            {
                Id = 3,
                PmName = null,
                ManagerName = string.Empty,
                PurchaserName = "purchaser name",
                StaffName = "staff name",
            };
            this._subCatDao
                .Stub(o => o.GetMany(Arg<IEnumerable<int>>.Is.Anything))
                .Return(new[] { subCatData1, subCatData2 });

            var pmData = new UserData
            {
                Name = "pm name",
            };
            var managerData = new UserData
            {
                Name = "manager name",
            };
            var purchaserData = new UserData
            {
                Name = "purchaser name",
            };
            var staffData = new UserData
            {
                Name = "staff name",
            };
            this._userDao
                .Stub(o => o.GetMany(Arg<IEnumerable<string>>.Is.Anything))
                .Return(new[] { pmData, managerData, purchaserData, staffData });

            ISubCategoryService target = new SubCategoryService(this._factory);
            var subCats = target.GetSubCategoryUsers(new[] { 1, 2, 3 });

            Assert.IsNotNull(subCats);
            Assert.AreEqual(2, subCats.Count());

            var subCat1 = subCats.ElementAt(0);
            Assert.AreEqual(1, subCat1.Id);
            Assert.IsNotNull(subCat1.Pm);
            Assert.AreEqual(pmData.Name, subCat1.Pm.Name);
            Assert.IsNotNull(subCat1.Manager);
            Assert.AreEqual(managerData.Name, subCat1.Manager.Name);
            Assert.IsNull(subCat1.Purchaser);
            Assert.IsNull(subCat1.Staff);

            var subCat2 = subCats.ElementAt(1);
            Assert.AreEqual(3, subCat2.Id);
            Assert.IsNull(subCat2.Pm);
            Assert.IsNull(subCat2.Manager);
            Assert.IsNotNull(subCat2.Purchaser);
            Assert.AreEqual(purchaserData.Name, subCat2.Purchaser.Name);
            Assert.IsNotNull(subCat2.Staff);
            Assert.AreEqual(staffData.Name, subCat2.Staff.Name);
        }
    }
}

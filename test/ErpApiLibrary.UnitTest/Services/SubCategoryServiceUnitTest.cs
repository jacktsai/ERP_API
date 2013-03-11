using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ErpApi.DAL;
using Rhino.Mocks;
using ErpApi.Entities;

namespace ErpApi.BLL
{
    [TestClass]
    public class SubCategoryServiceUnitTest
    {
        private IUserDao _userDao;
        private ISubCategoryDao _subCatDao;
        private ISubCategoryService _target;

        [TestInitialize]
        public void TestInitialize()
        {
            this._userDao = MockRepository.GenerateStub<IUserDao>();
            this._subCatDao = MockRepository.GenerateStub<ISubCategoryDao>();

            this._target = new SubCategoryService
            {
                UserDao = this._userDao,
                SubCategoryDao = this._subCatDao,
            };
        }

        [TestMethod]
        public void GetSubCategories_SubCat_null()
        {
            this._subCatDao
                .Stub(o => o.GetMany(Arg<IEnumerable<int>>.Is.Anything))
                .Return(null);

            var actual = this._target.GetSubCategoryUsers(new[] { 1 });

            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count());
        }

        [TestMethod]
        public void GetSubCategories_SubCat_ZeroLength()
        {
            this._subCatDao
                .Stub(o => o.GetMany(Arg<IEnumerable<int>>.Is.Anything))
                .Return(new SubCategory[0]);

            var actual = this._target.GetSubCategoryUsers(new[] { 1 });

            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count());
        }

        [TestMethod]
        public void GetSubCategories_User_null()
        {
            var subCat1 = new SubCategory
            {
                catsub_id = 1,
                User = new SubCategoryUser
                {
                    catsubusr_usrname = "pm name",
                },
                catsub_mdypm = "manager name",
                catsub_mdypurher = string.Empty,
                catsub_mdystaff = null,
            };
            var subCat2 = new SubCategory
            {
                catsub_id = 3,
                User = new SubCategoryUser(),
                catsub_mdypm = string.Empty,
                catsub_mdypurher = "purchaser name",
                catsub_mdystaff = "staff name",
            };
            this._subCatDao
                .Stub(o => o.GetMany(Arg<IEnumerable<int>>.Is.Anything))
                .Return(new[] { subCat1, subCat2 });

            this._userDao
                .Stub(o => o.GetMany(Arg<IEnumerable<string>>.Is.Anything))
                .Return(null);

            var subCats = this._target.GetSubCategoryUsers(new[] { 1, 2, 3 });

            Assert.IsNotNull(subCats);
            Assert.AreEqual(2, subCats.Count());

            var contact1 = subCats.ElementAt(0);
            Assert.AreEqual(1, subCat1.catsub_id);
            Assert.IsNull(contact1.Pm);
            Assert.IsNull(contact1.Manager);
            Assert.IsNull(contact1.Purchaser);
            Assert.IsNull(contact1.Staff);

            var contact2 = subCats.ElementAt(1);
            Assert.AreEqual(3, contact2.Id);
            Assert.IsNull(contact2.Pm);
            Assert.IsNull(contact2.Manager);
            Assert.IsNull(contact2.Purchaser);
            Assert.IsNull(contact2.Staff);
        }

        [TestMethod]
        public void GetSubCategories_User_ZeroLength()
        {
            var subCat1 = new SubCategory
            {
                catsub_id = 1,
                User = new SubCategoryUser
                {
                    catsubusr_usrname = "pm name",
                },
                catsub_mdypm = "manager name",
                catsub_mdypurher = string.Empty,
                catsub_mdystaff = null,
            };
            var subCat2 = new SubCategory
            {
                catsub_id = 3,
                User = new SubCategoryUser(),
                catsub_mdypm = string.Empty,
                catsub_mdypurher = "purchaser name",
                catsub_mdystaff = "staff name",
            };
            this._subCatDao
                .Stub(o => o.GetMany(Arg<IEnumerable<int>>.Is.Anything))
                .Return(new[] { subCat1, subCat2 });

            this._userDao
                .Stub(o => o.GetMany(Arg<IEnumerable<string>>.Is.Anything))
                .Return(new User[0]);

            var subCats = this._target.GetSubCategoryUsers(new[] { 1, 2, 3 });

            Assert.IsNotNull(subCats);
            Assert.AreEqual(2, subCats.Count());

            var contact1 = subCats.ElementAt(0);
            Assert.AreEqual(1, contact1.Id);
            Assert.IsNull(contact1.Pm);
            Assert.IsNull(contact1.Manager);
            Assert.IsNull(contact1.Purchaser);
            Assert.IsNull(contact1.Staff);

            var contact2 = subCats.ElementAt(1);
            Assert.AreEqual(3, contact2.Id);
            Assert.IsNull(contact2.Pm);
            Assert.IsNull(contact2.Manager);
            Assert.IsNull(contact2.Purchaser);
            Assert.IsNull(contact2.Staff);
        }

        [TestMethod]
        public void GetSubCategories()
        {
            var subCat1 = new SubCategory
            {
                catsub_id = 1,
                User = new SubCategoryUser
                {
                    catsubusr_usrname = "pm name",
                },
                catsub_mdypm = "manager name",
                catsub_mdypurher = string.Empty,
                catsub_mdystaff = null,
            };
            var subCat2 = new SubCategory
            {
                catsub_id = 3,
                User = new SubCategoryUser(),
                catsub_mdypm = string.Empty,
                catsub_mdypurher = "purchaser name",
                catsub_mdystaff = "staff name",
            };
            this._subCatDao
                .Stub(o => o.GetMany(Arg<IEnumerable<int>>.Is.Anything))
                .Return(new[] { subCat1, subCat2 });

            var pm = new User
            {
                priuser_name = "pm name",
            };
            var manager = new User
            {
                priuser_name = "manager name",
            };
            var purchaser = new User
            {
                priuser_name = "purchaser name",
            };
            var staff = new User
            {
                priuser_name = "staff name",
            };
            this._userDao
                .Stub(o => o.GetMany(Arg<IEnumerable<string>>.Is.Anything))
                .Return(new[] { pm, manager, purchaser, staff });

            var subCats = this._target.GetSubCategoryUsers(new[] { 1, 2, 3 });

            Assert.IsNotNull(subCats);
            Assert.AreEqual(2, subCats.Count());

            var contact1 = subCats.ElementAt(0);
            Assert.AreEqual(1, contact1.Id);
            Assert.IsNotNull(contact1.Pm);
            Assert.AreEqual(pm.priuser_name, contact1.Pm.priuser_name);
            Assert.IsNotNull(contact1.Manager);
            Assert.AreEqual(manager.priuser_name, contact1.Manager.priuser_name);
            Assert.IsNull(contact1.Purchaser);
            Assert.IsNull(contact1.Staff);

            var contact2 = subCats.ElementAt(1);
            Assert.AreEqual(3, contact2.Id);
            Assert.IsNull(contact2.Pm);
            Assert.IsNull(contact2.Manager);
            Assert.IsNotNull(contact2.Purchaser);
            Assert.AreEqual(purchaser.priuser_name, contact2.Purchaser.priuser_name);
            Assert.IsNotNull(contact2.Staff);
            Assert.AreEqual(staff.priuser_name, contact2.Staff.priuser_name);
        }
    }
}

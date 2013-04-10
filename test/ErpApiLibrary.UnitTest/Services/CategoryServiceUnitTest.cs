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
    public class CategoryServiceUnitTest
    {
        private IPriUserDao _userDao;
        private ICatSubDao _subCatDao;
        private ICategoryService _target;

        [TestInitialize]
        public void TestInitialize()
        {
            this._userDao = MockRepository.GenerateStub<IPriUserDao>();
            this._subCatDao = MockRepository.GenerateStub<ICatSubDao>();

            this._target = new CategoryService
            {
                PriUserDao = this._userDao,
                CatSubDao = this._subCatDao,
            };
        }

        [TestMethod]
        public void GetCategories_Category_null()
        {
            this._subCatDao
                .Stub(o => o.GetMany(Arg<IEnumerable<int>>.Is.Anything))
                .Return(null);

            var actual = this._target.GetCategoryContacts(new[] { 1 });

            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count());
        }

        [TestMethod]
        public void GetCategories_Category_ZeroLength()
        {
            this._subCatDao
                .Stub(o => o.GetMany(Arg<IEnumerable<int>>.Is.Anything))
                .Return(new CatSub[0]);

            var actual = this._target.GetCategoryContacts(new[] { 1 });

            Assert.IsNotNull(actual);
            Assert.AreEqual(0, actual.Count());
        }

        [TestMethod]
        public void GetCategories_User_null()
        {
            var subCat1 = new CatSub
            {
                Id = 1,
                User = new CatSubUsr
                {
                    UsrName = "pm name",
                },
                MdyPm = "manager name",
                MdyPurher = string.Empty,
                MdyStaff = null,
            };
            var subCat2 = new CatSub
            {
                Id = 3,
                User = new CatSubUsr(),
                MdyPm = string.Empty,
                MdyPurher = "purchaser name",
                MdyStaff = "staff name",
            };
            this._subCatDao
                .Stub(o => o.GetMany(Arg<IEnumerable<int>>.Is.Anything))
                .Return(new[] { subCat1, subCat2 });

            this._userDao
                .Stub(o => o.GetMany(Arg<IEnumerable<string>>.Is.Anything))
                .Return(null);

            var subCats = this._target.GetCategoryContacts(new[] { 1, 2, 3 });

            Assert.IsNotNull(subCats);
            Assert.AreEqual(2, subCats.Count());

            var contact1 = subCats.ElementAt(0);
            Assert.AreEqual(1, subCat1.Id);
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
        public void GetCategories_User_ZeroLength()
        {
            var subCat1 = new CatSub
            {
                Id = 1,
                User = new CatSubUsr
                {
                    UsrName = "pm name",
                },
                MdyPm = "manager name",
                MdyPurher = string.Empty,
                MdyStaff = null,
            };
            var subCat2 = new CatSub
            {
                Id = 3,
                User = new CatSubUsr(),
                MdyPm = string.Empty,
                MdyPurher = "purchaser name",
                MdyStaff = "staff name",
            };
            this._subCatDao
                .Stub(o => o.GetMany(Arg<IEnumerable<int>>.Is.Anything))
                .Return(new[] { subCat1, subCat2 });

            this._userDao
                .Stub(o => o.GetMany(Arg<IEnumerable<string>>.Is.Anything))
                .Return(new PriUser[0]);

            var subCats = this._target.GetCategoryContacts(new[] { 1, 2, 3 });

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
        public void GetCategories()
        {
            var subCat1 = new CatSub
            {
                Id = 1,
                User = new CatSubUsr
                {
                    UsrName = "pm name",
                },
                MdyPm = "manager name",
                MdyPurher = string.Empty,
                MdyStaff = null,
            };
            var subCat2 = new CatSub
            {
                Id = 3,
                User = new CatSubUsr(),
                MdyPm = string.Empty,
                MdyPurher = "purchaser name",
                MdyStaff = "staff name",
            };
            this._subCatDao
                .Stub(o => o.GetMany(Arg<IEnumerable<int>>.Is.Anything))
                .Return(new[] { subCat1, subCat2 });

            var pm = new PriUser
            {
                Name = "pm name",
            };
            var manager = new PriUser
            {
                Name = "manager name",
            };
            var purchaser = new PriUser
            {
                Name = "purchaser name",
            };
            var staff = new PriUser
            {
                Name = "staff name",
            };
            this._userDao
                .Stub(o => o.GetMany(Arg<IEnumerable<string>>.Is.Anything))
                .Return(new[] { pm, manager, purchaser, staff });

            var subCats = this._target.GetCategoryContacts(new[] { 1, 2, 3 });

            Assert.IsNotNull(subCats);
            Assert.AreEqual(2, subCats.Count());

            var contact1 = subCats.ElementAt(0);
            Assert.AreEqual(1, contact1.Id);
            Assert.IsNotNull(contact1.Pm);
            Assert.AreEqual(pm.Name, contact1.Pm.Name);
            Assert.IsNotNull(contact1.Manager);
            Assert.AreEqual(manager.Name, contact1.Manager.Name);
            Assert.IsNull(contact1.Purchaser);
            Assert.IsNull(contact1.Staff);

            var contact2 = subCats.ElementAt(1);
            Assert.AreEqual(3, contact2.Id);
            Assert.IsNull(contact2.Pm);
            Assert.IsNull(contact2.Manager);
            Assert.IsNotNull(contact2.Purchaser);
            Assert.AreEqual(purchaser.Name, contact2.Purchaser.Name);
            Assert.IsNotNull(contact2.Staff);
            Assert.AreEqual(staff.Name, contact2.Staff.Name);
        }
    }
}

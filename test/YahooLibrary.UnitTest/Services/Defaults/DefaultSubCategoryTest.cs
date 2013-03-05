using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Yahoo.Data;
using System.Threading.Tasks;

namespace Yahoo.Services.Defaults
{
    [TestClass]
    public class DefaultSubCategoryTest
    {
        private IDaoFactory factory;
        private ISubCategoryDao subCatDao;
        private IUserDao userDao;
        private UserData userData;

        [TestInitialize]
        public void TestInitialize()
        {
            this.subCatDao = MockRepository.GenerateStub<ISubCategoryDao>();
            this.userDao = MockRepository.GenerateStub<IUserDao>();

            this.factory = MockRepository.GenerateStub<IDaoFactory>();
            
            this.factory
                .Stub(o => o.GetSubCategoryDao())
                .Return(subCatDao);

            this.factory
                .Stub(o => o.GetUserDao())
                .Return(userDao);

            userData = new UserData
            {
                BackyardId = "jacktsai",
                FullName = "Jack Tsai",
                ExtNumber = "3388",
                Email = "jacktsai@yahoo-inc.com"
            };
        }

        [TestMethod]
        public void GetUser()
        {
            var subCatData = new SubCategoryData
            {
                UserName = "user",
            };
            var subCatSource = new TaskCompletionSource<SubCategoryData>();
            subCatSource.SetResult(subCatData);
            subCatDao
                .Stub(o => o.GetOneAsync(1))
                .Return(subCatSource.Task);

            var userSource = new TaskCompletionSource<UserData>();
            userSource.SetResult(userData);
            userDao
                .Stub(o => o.GetOneAsync(name: "user"))
                .Return(userSource.Task);

            ISubCategory target = new DefaultSubCategory(this.factory, 1);
            var actual = target.User;

            Assert.IsNotNull(actual);
            Assert.AreEqual(userData.BackyardId, actual.BackyardId);
            Assert.AreEqual(userData.FullName, actual.FullName);
            Assert.AreEqual(userData.ExtNumber, actual.ExtNumber);
            Assert.AreEqual(userData.Email, actual.Email);
        }

        [TestMethod]
        public void GetManager()
        {
            var subCatData = new SubCategoryData
            {
                ManagerName = "manager",
            };
            var subCatSource = new TaskCompletionSource<SubCategoryData>();
            subCatSource.SetResult(subCatData);
            subCatDao
                .Stub(o => o.GetOneAsync(1))
                .Return(subCatSource.Task);

            var userSource = new TaskCompletionSource<UserData>();
            userSource.SetResult(userData);
            userDao
                .Stub(o => o.GetOneAsync(name: "manager"))
                .Return(userSource.Task);

            ISubCategory target = new DefaultSubCategory(this.factory, 1);
            var actual = target.Manager;

            Assert.IsNotNull(actual);
            Assert.AreEqual(userData.BackyardId, actual.BackyardId);
            Assert.AreEqual(userData.FullName, actual.FullName);
            Assert.AreEqual(userData.ExtNumber, actual.ExtNumber);
            Assert.AreEqual(userData.Email, actual.Email);
        }

        [TestMethod]
        public void GetPurchaser()
        {
            var subCatData = new SubCategoryData
            {
                PurchaserName = "purchaser",
            };
            var subCatSource = new TaskCompletionSource<SubCategoryData>();
            subCatSource.SetResult(subCatData);
            subCatDao
                .Stub(o => o.GetOneAsync(1))
                .Return(subCatSource.Task);

            var userSource = new TaskCompletionSource<UserData>();
            userSource.SetResult(userData);
            userDao
                .Stub(o => o.GetOneAsync(name: "purchaser"))
                .Return(userSource.Task);

            ISubCategory target = new DefaultSubCategory(this.factory, 1);
            var actual = target.Purchaser;

            Assert.IsNotNull(actual);
            Assert.AreEqual(userData.BackyardId, actual.BackyardId);
            Assert.AreEqual(userData.FullName, actual.FullName);
            Assert.AreEqual(userData.ExtNumber, actual.ExtNumber);
            Assert.AreEqual(userData.Email, actual.Email);
        }

        [TestMethod]
        public void GetStaff()
        {
            var subCatData = new SubCategoryData
            {
                StaffName = "staff",
            };
            var subCatSource = new TaskCompletionSource<SubCategoryData>();
            subCatSource.SetResult(subCatData);
            subCatDao
                .Stub(o => o.GetOneAsync(1))
                .Return(subCatSource.Task);

            var userSource = new TaskCompletionSource<UserData>();
            userSource.SetResult(userData);
            userDao
                .Stub(o => o.GetOneAsync(name: "staff"))
                .Return(userSource.Task);

            ISubCategory target = new DefaultSubCategory(this.factory, 1);
            var actual = target.Staff;

            Assert.IsNotNull(actual);
            Assert.AreEqual(userData.BackyardId, actual.BackyardId);
            Assert.AreEqual(userData.FullName, actual.FullName);
            Assert.AreEqual(userData.ExtNumber, actual.ExtNumber);
            Assert.AreEqual(userData.Email, actual.Email);
        }
    }
}

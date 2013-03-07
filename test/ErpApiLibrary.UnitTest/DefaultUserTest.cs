using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using ErpApi.Data;
using System.Threading.Tasks;

namespace ErpApi
{
    [TestClass]
    public class DefaultUserTest
    {
        private readonly UserData sample;
        private IDaoFactory factory;
        private IUserDao userDao;

        public DefaultUserTest()
        {
            sample = new UserData
            {
                Id = 2733,
                Name = "jack",
                FullName = "Jack Tsai",
                Department = "department",
                Degree = 1,
                Email = "my email",
                Homepage = "homepage",
                ExtNumber = "12345",
                BackyardId = "jacktsai",
            };
        }

        protected void AssertWithSample(IUser actual)
        {
            Assert.AreEqual(sample.Id, actual.Id);
            Assert.AreEqual(sample.Name, actual.Name);
            Assert.AreEqual(sample.FullName, actual.FullName);
            Assert.AreEqual(sample.Department, actual.Department);
            Assert.AreEqual(sample.Degree, actual.Degree);
            Assert.AreEqual(sample.Email, actual.Email);
            Assert.AreEqual(sample.Homepage, actual.Homepage);
            Assert.AreEqual(sample.ExtNumber, actual.ExtNumber);
            Assert.AreEqual(sample.BackyardId, actual.BackyardId);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_factory_null_id_2733()
        {
            new DefaultUser(null, id: 2733);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void Ctor_factory_notnull_id_null_name_null_backyardId_null()
        {
            new DefaultUser(this.factory, id: null, name: null, backyardId: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_factory_null_data_null()
        {
            new DefaultUser(this.factory, data: null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_factory_null_data_sample()
        {
            new DefaultUser(null, data: sample);
        }

        [TestMethod]
        public void Ctor_factory_notnull_data_sample()
        {
            var target = new DefaultUser(this.factory, sample);

            AssertWithSample(target);
        }

        [TestInitialize]
        public void TestInitialize()
        {
            this.userDao = MockRepository.GenerateStub<IUserDao>();

            this.factory = MockRepository.GenerateStub<IDaoFactory>();
            this.factory
                .Stub(o => o.GetUserDao())
                .Return(userDao);
        }

        [TestMethod]
        public void LoadAsync_id()
        {
            var source = new TaskCompletionSource<UserData>();
            source.SetResult(sample);
            userDao
                .Stub(o => o.GetOne(id: 2733))
                .Return(source.Task);

            var target = new DefaultUser(this.factory, id: 2733);

            AssertWithSample(target);
        }

        [TestMethod]
        public void LoadAsync_name()
        {
            var source = new TaskCompletionSource<UserData>();
            source.SetResult(sample);
            userDao
                .Stub(o => o.GetOne(name: "jack"))
                .Return(source.Task);

            var target = new DefaultUser(this.factory, name: "jack");

            AssertWithSample(target);
        }

        [TestMethod]
        public void LoadAsync_backyardId()
        {
            var source = new TaskCompletionSource<UserData>();
            source.SetResult(sample);
            userDao
                .Stub(o => o.GetOne(backyardId: "jacktsai"))
                .Return(source.Task);

            var target = new DefaultUser(this.factory, backyardId: "jacktsai");

            AssertWithSample(target);
        }

        [TestMethod]
        [ExpectedException(typeof(UserNotFoundException))]
        public void LoadAsync_UserNotFound()
        {
            var source = new TaskCompletionSource<UserData>();
            source.SetResult(null);
            userDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(source.Task);

            var target = new DefaultUser(this.factory, Arg<int>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything);

            try
            {
                target.LoadAsync().Wait();
            }
            catch (AggregateException ex)
            {
                throw ex.InnerException;
            }
        }

        [TestMethod]
        public void Get_Roles()
        {
            var target = new DefaultUser(this.factory, sample) as IUser;

            Assert.IsNotNull(target.Roles);
        }

        [TestMethod]
        public void Get_Privileges()
        {
            var target = new DefaultUser(this.factory, sample) as IUser;

            Assert.IsNotNull(target.Privileges);
        }

        [TestMethod]
        public void Get_SubCategories()
        {
            var target = new DefaultUser(this.factory, sample) as IUser;

            Assert.IsNotNull(target.SubCategories);
        }
    }
}

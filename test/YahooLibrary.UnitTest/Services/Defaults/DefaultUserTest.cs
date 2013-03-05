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
    public class DefaultUserTest
    {
        private IDaoFactory factory;
        private IUserDao userDao;

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
        public void LoadAsync()
        {
            var expected = new UserData
            {
                Id = 2733,
                Name = "jacktsai",
                FullName = "Jack Tsai",
                BackyardId = "jacktsai",
            };

            var source = new TaskCompletionSource<UserData>();
            source.SetResult(expected);
            userDao
                .Stub(o => o.GetOneAsync())
                .Return(source.Task);

            var target = new DefaultUser(this.factory);
            target.LoadAsync().Wait();

            var actual = target as IUser;

            Assert.AreEqual(expected.BackyardId, actual.BackyardId);
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.FullName, actual.FullName);
        }
    }
}

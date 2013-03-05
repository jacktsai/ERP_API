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
    public class DefaultPrivilegeCollectionTest
    {
        private IDaoFactory factory;
        private IPrivilegeDao privilegeDao;

        [TestInitialize]
        public void TestInitialize()
        {
            this.privilegeDao = MockRepository.GenerateStub<IPrivilegeDao>();

            this.factory = MockRepository.GenerateStub<IDaoFactory>();
            this.factory
                .Stub(o => o.GetPrivilegeDao())
                .Return(privilegeDao);
        }

        [TestMethod]
        public void GetPrivileges()
        {
            var privilegeDatas = new PrivilegeData[]
            {
                new PrivilegeData { Url = "url1", Name = "name1" },
                new PrivilegeData { Url = "url2", Name = "name2" },
                new PrivilegeData { Url = "url3", Name = "name3" },
            };
            var privilegeSource = new TaskCompletionSource<IEnumerable<PrivilegeData>>();
            privilegeSource.SetResult(privilegeDatas);
            privilegeDao
                .Stub(o => o.GetManyAsync(Arg<int>.Is.Anything))
                .Return(privilegeSource.Task);

            var user = MockRepository.GenerateStub<IUser>();
            user
                .Stub(o => o.Id)
                .Return(1);

            var target = new DefaultPrivilegeCollection(this.factory, user);
            var privileges = target.ToArray();

            Assert.AreEqual(privilegeDatas.Length, privileges.Length);
            for (int i = 0; i < privilegeDatas.Length; i++)
            {
                Assert.AreEqual(privilegeDatas[i].Url, privileges[i].Url);
                Assert.AreEqual(privilegeDatas[i].Name, privileges[i].Name);
            }
        }

        [TestMethod]
        public void FindPrivilege()
        {
            var userId = 1;
            var url = "url1";

            var privilegeData = new PrivilegeData { Url = url, Name = "name1" };
            var privilegeSource = new TaskCompletionSource<PrivilegeData>();
            privilegeSource.SetResult(privilegeData);
            privilegeDao
                .Stub(o => o.GetOneAsync(userId, url))
                .Return(privilegeSource.Task);

            var user = MockRepository.GenerateStub<IUser>();
            user
                .Stub(o => o.Id)
                .Return(userId);

            var target = new DefaultPrivilegeCollection(this.factory, user) as IPrivilegeCollection;
            var actual = target.Find(url);

            Assert.AreEqual(privilegeData.Url, actual.Url);
            Assert.AreEqual(privilegeData.Name, actual.Name);
        }
    }
}

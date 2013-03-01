using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Yahoo.DataAccess;
using System.Threading.Tasks;

namespace Yahoo.Business
{
    [TestClass]
    public class DefaultPrivilegeCollectionTest
    {
        private IBusinessFactory factory;
        private IPrivilegeDao privilegeDao;

        [TestInitialize]
        public void TestInitialize()
        {
            this.privilegeDao = MockRepository.GenerateStub<IPrivilegeDao>();

            this.factory = MockRepository.GenerateStub<IBusinessFactory>();
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
    }
}

using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahoo.Data;
using System.Threading.Tasks;
using Rhino.Mocks;

namespace Yahoo.Services.Defaults
{
    [TestClass]
    public class DefaultRoleCollectionTest
    {
        private IDaoFactory factory;
        private IRoleDao roleDao;

        [TestInitialize]
        public void TestInitialize()
        {
            this.roleDao = MockRepository.GenerateStub<IRoleDao>();

            this.factory = MockRepository.GenerateStub<IDaoFactory>();
            this.factory
                .Stub(o => o.GetRoleDao())
                .Return(roleDao);
        }

        [TestMethod]
        public void GetRoles()
        {
            var roleDatas = new RoleData[]
            {
                new RoleData { Id = 1, Name = "role1", CanSelect = false, CanInsert = false, CanUpdate = false, CanDelete = false, CanParticular = false },
                new RoleData { Id = 2, Name = "role2", CanSelect = true, CanInsert = false, CanUpdate = false, CanDelete = false, CanParticular = false },
                new RoleData { Id = 3, Name = "role3", CanSelect = false, CanInsert = true, CanUpdate = false, CanDelete = false, CanParticular = false },
                new RoleData { Id = 4, Name = "role4", CanSelect = false, CanInsert = false, CanUpdate = true, CanDelete = false, CanParticular = false },
                new RoleData { Id = 5, Name = "role5", CanSelect = false, CanInsert = false, CanUpdate = false, CanDelete = true, CanParticular = false },
                new RoleData { Id = 6, Name = "role6", CanSelect = false, CanInsert = false, CanUpdate = false, CanDelete = false, CanParticular = true },
            };

            var roleSource = new TaskCompletionSource<IEnumerable<RoleData>>();
            roleSource.SetResult(roleDatas);
            roleDao
                .Stub(o => o.GetManyAsync(Arg<int>.Is.Anything))
                .Return(roleSource.Task);

            var user = MockRepository.GenerateStub<IUser>();
            user
                .Stub(o => o.Id)
                .Return(1);

            var target = new DefaultRoleCollection(this.factory, user) as IRoleCollection;
            var roles = target.ToArray();

            Assert.AreEqual(roleDatas.Length, roles.Length);
            for (int i = 0; i < roleDatas.Length; i++)
            {
                Assert.AreEqual(roleDatas[i].Name, roles[i].Name);
                Assert.AreEqual(roleDatas[i].CanSelect, roles[i].CanSelect);
                Assert.AreEqual(roleDatas[i].CanInsert, roles[i].CanInsert);
                Assert.AreEqual(roleDatas[i].CanUpdate, roles[i].CanUpdate);
                Assert.AreEqual(roleDatas[i].CanDelete, roles[i].CanDelete);
                Assert.AreEqual(roleDatas[i].CanParticular, roles[i].CanParticular);
            }
            Assert.IsTrue(target.HasSelect);
            Assert.IsTrue(target.HasInsert);
            Assert.IsTrue(target.HasUpdate);
            Assert.IsTrue(target.HasDelete);
            Assert.IsTrue(target.HasParticular);
        }
    }
}

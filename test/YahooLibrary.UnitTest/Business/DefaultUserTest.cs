using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Yahoo.DataAccess;
using Yahoo.Business.Security.Cryptography;
using Yahoo.Business.Security;
using System.Threading.Tasks;

namespace Yahoo.Business
{
    [TestClass]
    public class DefaultUserTest
    {
        private IBusinessFactory factory;
        private IUserDao userDao;
        private IRoleDao roleDao;
        private IPrivilegeDao privilegeDao;
        private IAuthorityDao authorityDao;
        private ICatPrivilegeDao catPrivilegeDao;

        [TestInitialize]
        public void TestInitialize()
        {
            this.userDao = MockRepository.GenerateStub<IUserDao>();
            this.roleDao = MockRepository.GenerateStub<IRoleDao>();
            this.privilegeDao = MockRepository.GenerateStub<IPrivilegeDao>();
            this.authorityDao = MockRepository.GenerateStub<IAuthorityDao>();
            this.catPrivilegeDao = MockRepository.GenerateStub<ICatPrivilegeDao>();

            this.factory = MockRepository.GenerateStub<IBusinessFactory>();
            this.factory
                .Stub(o => o.GetUserDao())
                .Return(userDao);
            this.factory
                .Stub(o => o.GetRoleDao())
                .Return(roleDao);
            this.factory
                .Stub(o => o.GetPrivilegeDao())
                .Return(privilegeDao);
            this.factory
                .Stub(o => o.GetAuthorityDao())
                .Return(authorityDao);
            this.factory
                .Stub(o => o.GetCatPrivilegeDao())
                .Return(catPrivilegeDao);
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
                .Stub(o => o.GetOneAsync(Arg<string>.Is.Anything))
                .Return(source.Task);

            IUser target = new DefaultUser(this.factory);
            target.LoadAsync(string.Empty).Wait();

            Assert.AreEqual(expected.BackyardId, target.BackyardId);
            Assert.AreEqual(expected.Id, target.Id);
            Assert.AreEqual(expected.Name, target.Name);
            Assert.AreEqual(expected.FullName, target.FullName);
        }

        // TODO: move to DefaultRoleCollectionTest
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

            IUser target = new DefaultUser(this.factory, userId: 1);
            var roles = target.Roles.ToArray();

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
            Assert.IsTrue(target.Roles.HasSelect);
            Assert.IsTrue(target.Roles.HasInsert);
            Assert.IsTrue(target.Roles.HasUpdate);
            Assert.IsTrue(target.Roles.HasDelete);
            Assert.IsTrue(target.Roles.HasParticular);
        }

        // TODO: move to DefaultPrivilegeTest
        [TestMethod]
        public void FindAuthority()
        {
            var privilegeData = new PrivilegeData { Url = "url1", Name = "name1" };
            var privilegeSource = new TaskCompletionSource<PrivilegeData>();
            privilegeSource.SetResult(privilegeData);
            privilegeDao
                .Stub(o => o.GetOneAsync(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(privilegeSource.Task);

            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanSelect = true, CanInsert = true, CanUpdate = true, CanDelete = false, CanParticular = false },
                new AuthorityData { DenySelect = false, DenyInsert = null, DenyUpdate = true, DenyDelete = null, DenyParticular = true },
            };
            var authoritySource = new TaskCompletionSource<IEnumerable<AuthorityData>>();
            authoritySource.SetResult(authorityDatas);
            authorityDao
                .Stub(o => o.GetManyAsync(Arg<int>.Is.Anything, Arg<string>.Is.Anything))
                .Return(authoritySource.Task);

            IUser target = new DefaultUser(this.factory, userId: 1);
            var privilege = target.Privileges.Find(Arg<string>.Is.Anything);

            Assert.AreEqual(privilegeData.Url, privilege.Url);
            Assert.AreEqual(privilegeData.Name, privilege.Name);

            var authority = privilege.Authority;
            Assert.AreEqual(true, authority.CanSelect);
            Assert.AreEqual(true, authority.CanInsert);
            Assert.AreEqual(false, authority.CanUpdate);
            Assert.AreEqual(false, authority.CanDelete);
            Assert.AreEqual(false, authority.CanParticular);
        }

        // TODO: move to DefaultCatPrivilegeCollectionTest
        [TestMethod]
        public void GetCatPrivileges()
        {
            var catPrivilegeDatas = new CatPrivilegeData[]
            {
                new CatPrivilegeData { ZoneId = 1, ZoneName = "zone name 1", SubId = 11, SubName = "sub name 11" },
                new CatPrivilegeData { ZoneId = 2, ZoneName = "zone name 2", SubId = 22, SubName = "sub name 22" },
                new CatPrivilegeData { ZoneId = 3, ZoneName = "zone name 3", SubId = 33, SubName = "sub name 33" },
            };
            var catPrivilegeSource = new TaskCompletionSource<IEnumerable<CatPrivilegeData>>();
            catPrivilegeSource.SetResult(catPrivilegeDatas);
            catPrivilegeDao
                .Stub(o => o.GetManyAsync(Arg<int>.Is.Anything))
                .Return(catPrivilegeSource.Task);

            IUser target = new DefaultUser(this.factory, userId: 1);
            var catPrivileges = target.CatPrivileges.ToArray();

            Assert.AreEqual(catPrivilegeDatas.Length, catPrivileges.Length);
            Assert.AreEqual(catPrivilegeDatas[0].ZoneId, catPrivileges[0].ZoneId);
            Assert.AreEqual(catPrivilegeDatas[0].ZoneName, catPrivileges[0].ZoneName);
            Assert.AreEqual(catPrivilegeDatas[0].SubId, catPrivileges[0].SubId);
            Assert.AreEqual(catPrivilegeDatas[0].SubName, catPrivileges[0].SubName);
            Assert.AreEqual(catPrivilegeDatas[1].ZoneId, catPrivileges[1].ZoneId);
            Assert.AreEqual(catPrivilegeDatas[1].ZoneName, catPrivileges[1].ZoneName);
            Assert.AreEqual(catPrivilegeDatas[1].SubId, catPrivileges[1].SubId);
            Assert.AreEqual(catPrivilegeDatas[1].SubName, catPrivileges[1].SubName);
            Assert.AreEqual(catPrivilegeDatas[2].ZoneId, catPrivileges[2].ZoneId);
            Assert.AreEqual(catPrivilegeDatas[2].ZoneName, catPrivileges[2].ZoneName);
            Assert.AreEqual(catPrivilegeDatas[2].SubId, catPrivileges[2].SubId);
            Assert.AreEqual(catPrivilegeDatas[2].SubName, catPrivileges[2].SubName);
        }
    }
}

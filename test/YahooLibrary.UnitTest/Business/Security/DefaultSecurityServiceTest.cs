using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Yahoo.Business.Security.Cryptography;
using Yahoo.DataAccess;

namespace Yahoo.Business.Security
{
    [TestClass]
    public class DefaultSecurityServiceTest
    {
        private IUserDao userDao;
        private IRoleDao roleDao;
        private IPrivilegeDao privilegeDao;
        private IFunctionDao functionDao;
        private IHashProvider hashProvider;
        private ISecurityService target;

        [TestInitialize]
        public void TestInitialize()
        {
            userDao = MockRepository.GenerateStub<IUserDao>();
            roleDao = MockRepository.GenerateStub<IRoleDao>();
            privilegeDao = MockRepository.GenerateStub<IPrivilegeDao>();
            functionDao = MockRepository.GenerateStub<IFunctionDao>();
            hashProvider = MockRepository.GenerateStub<IHashProvider>();

            target = new DefaultSecurityService(userDao, roleDao, privilegeDao, functionDao, hashProvider);
        }

        [TestMethod]
        public void GetProfile_actual_null()
        {
            userDao
                .Stub(o => o.GetOne(Arg<int>.Is.Anything, Arg<string>.Is.Anything, Arg<string>.Is.Anything))
                .Return(null);

            var actual = target.GetProfile(9999);
            Assert.IsNull(actual);
        }

        [TestMethod]
        public void GetProfile_happy_case()
        {
            userDao
                .Stub(o => o.GetOne())
                .Return(new User
                    {
                        Id = 1,
                        Name = "jacktsai",
                        FullName = "Jack Tsai",
                        Department = "研發",
                        Degree = 0,
                        Homepage = "http://",
                        ExtensionNumber = "12345",
                        BackyardId = "jacktsai"
                    });

            roleDao
                .Expect(o => o.GetMany())
                .Return(new Role[]
                    {
                        new Role { Id = 1, HasSelect = true },
                        new Role { Id = 2, HasInsert = true },
                        new Role { Id = 3, HasUpdate = true },
                        new Role { Id = 4, HasDelete = false },
                        new Role { Id = 5, HasParticular = null },
                    });

            privilegeDao
                .Expect(o => o.GetMany())
                .Return(new Privilege[]
                    {
                        new Privilege { Id = 1, FunctionId = 11 },
                        new Privilege { Id = 2, FunctionId = 22 },
                        new Privilege { Id = 3, FunctionId = 33 },
                    });

            functionDao
                .Expect(o => o.GetMany(null))
                .IgnoreArguments()
                .Return(new Function[]
                    {
                        new Function { Id = 11, CategoryId = 4, CategorySubId = 7 },
                        new Function { Id = 22, CategoryId = 5, CategorySubId = 8 },
                        new Function { Id = 33, CategoryId = 6, CategorySubId = 9 },
                    });

            var actual = target.GetProfile(1);

            Assert.IsNotNull(actual);
            Assert.AreEqual(1, actual.Id);
            Assert.AreEqual("jacktsai", actual.Name);
            Assert.AreEqual("Jack Tsai", actual.FullName);
            Assert.AreEqual("研發", actual.Department);
            Assert.AreEqual(0, actual.Degree);
            Assert.AreEqual("http://", actual.Homepage);
            Assert.AreEqual("12345", actual.ExtensionNumber);
            Assert.AreEqual("jacktsai", actual.BackyardId);

            Assert.IsNotNull(actual.PrivilegeInfos);
            Assert.AreEqual(3, actual.PrivilegeInfos.Length);

            Assert.AreEqual(1, actual.PrivilegeInfos[0].Id);
            Assert.AreEqual(11, actual.PrivilegeInfos[0].FunctionId);
            Assert.AreEqual(4, actual.PrivilegeInfos[0].CategoryId);
            Assert.AreEqual(7, actual.PrivilegeInfos[0].CategorySubId);

            Assert.AreEqual(2, actual.PrivilegeInfos[1].Id);
            Assert.AreEqual(22, actual.PrivilegeInfos[1].FunctionId);
            Assert.AreEqual(5, actual.PrivilegeInfos[1].CategoryId);
            Assert.AreEqual(8, actual.PrivilegeInfos[1].CategorySubId);

            Assert.AreEqual(3, actual.PrivilegeInfos[2].Id);
            Assert.AreEqual(33, actual.PrivilegeInfos[2].FunctionId);
            Assert.AreEqual(6, actual.PrivilegeInfos[2].CategoryId);
            Assert.AreEqual(9, actual.PrivilegeInfos[2].CategorySubId);

            Assert.AreEqual(true, actual.HasSelect);
            Assert.AreEqual(true, actual.HasInsert);
            Assert.AreEqual(true, actual.HasUpdate);
            Assert.AreEqual(false, actual.HasDelete);
            Assert.AreEqual(false, actual.HasParticular);
        }
    }
}

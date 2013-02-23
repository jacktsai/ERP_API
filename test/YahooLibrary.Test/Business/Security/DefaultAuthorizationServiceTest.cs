using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using Yahoo.Business.Security.Cryptography;
using Yahoo.DataAccess;
using Yahoo.Business.Security;

namespace YahooLibrary.Business.Security
{
    [TestClass]
    public class DefaultAuthorizationServiceTest
    {
        [TestMethod]
        public void GetPrivilege_()
        {
            var userId = 1;
            var expected = (new PrivilegeInfo[]
            {
                new PrivilegeInfo { Id = 1 },
                new PrivilegeInfo { Id = 2 },
                new PrivilegeInfo { Id = 3 },
            }).ToList();

            var privilegeDao = MockRepository.GenerateMock<IPrivilegeDao>();
            privilegeDao
                .Expect(o => o.GetMany(userId: userId))
                .Return(new Privilege[]
                    {
                        new Privilege { Id = 1 },
                        new Privilege { Id = 2 },
                        new Privilege { Id = 3 },
                    });

            var target = new DefaultAuthorizationService(privilegeDao) as IAuthorizationService;
            var actual = target.GetPrivileges(userId: userId).ToList();

            privilegeDao.VerifyAllExpectations();
            CollectionAssert.AreEqual(expected, actual);
        }
    }
}

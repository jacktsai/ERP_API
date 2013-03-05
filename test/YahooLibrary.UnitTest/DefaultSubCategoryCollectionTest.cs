using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahoo.Data;
using System.Threading.Tasks;
using Rhino.Mocks;

namespace Yahoo
{
    [TestClass]
    public class DefaultSubCategoryCollectionTest
    {
        private IDaoFactory factory;
        private ISubCategoryDao subCategoryDao;

        [TestInitialize]
        public void TestInitialize()
        {
            this.subCategoryDao = MockRepository.GenerateStub<ISubCategoryDao>();

            this.factory = MockRepository.GenerateStub<IDaoFactory>();
            this.factory
                .Stub(o => o.GetSubCategoryDao())
                .Return(subCategoryDao);
        }

        [TestMethod]
        public void GetCatPrivileges()
        {
            var expected = new SubCategoryData[]
            {
                new SubCategoryData { ZoneId = 1, Id = 11, Name = "sub name 11" },
                new SubCategoryData { ZoneId = 2, Id = 22, Name = "sub name 22" },
                new SubCategoryData { ZoneId = 3, Id = 33, Name = "sub name 33" },
            };
            var catPrivilegeSource = new TaskCompletionSource<IEnumerable<SubCategoryData>>();
            catPrivilegeSource.SetResult(expected);
            subCategoryDao
                .Stub(o => o.GetManyAsync(Arg<int>.Is.Anything))
                .Return(catPrivilegeSource.Task);

            var user = MockRepository.GenerateStub<IUser>();
            user
                .Stub(o => o.Id)
                .Return(1);

            ISubCategoryCollection target = new DefaultSubCategoryCollection(this.factory, user);
            var actual = target.ToArray();

            Assert.AreEqual(expected.Length, actual.Length);
            Assert.AreEqual(expected[0].ZoneId, actual[0].ZoneId);
            Assert.AreEqual(expected[0].Id, actual[0].Id);
            Assert.AreEqual(expected[0].Name, actual[0].Name);
            Assert.AreEqual(expected[1].ZoneId, actual[1].ZoneId);
            Assert.AreEqual(expected[1].Id, actual[1].Id);
            Assert.AreEqual(expected[1].Name, actual[1].Name);
            Assert.AreEqual(expected[2].ZoneId, actual[2].ZoneId);
            Assert.AreEqual(expected[2].Id, actual[2].Id);
            Assert.AreEqual(expected[2].Name, actual[2].Name);
        }
    }
}

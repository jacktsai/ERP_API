using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpApi.Data.Common
{
    [TestClass]
    public class AuthorityDaoTest
    {
        [TestMethod]
        public void GetOne_backyardId_jacktsai_url_testaspx()
        {
            IAuthorityDao target = new AuthorityDao();
            var data = target.GetOne("jacktsai", "/test.aspx");

            Assert.IsNotNull(data);
            Assert.IsTrue(data.CanSelect);
            Assert.IsTrue(data.CanInsert);
            Assert.IsTrue(data.CanUpdate);
            Assert.IsTrue(data.CanDelete);
            Assert.IsTrue(data.CanParticular);
        }
    }
}

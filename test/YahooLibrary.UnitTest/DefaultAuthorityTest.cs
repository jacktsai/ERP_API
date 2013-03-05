using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahoo.Data;
using Rhino.Mocks;
using System.Threading.Tasks;

namespace Yahoo
{
    [TestClass]
    public class DefaultAuthorityTest
    {
        [TestMethod]
        public void CanSelect_true_DenySelect_null()
        {
            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanSelect = true, DenySelect = null },
            };

            var target = new DefaultAuthority(authorityDatas) as IAuthority;

            Assert.IsTrue(target.CanSelect);
        }

        [TestMethod]
        public void CanSelect_true_DenySelect_false()
        {
            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanSelect = true, DenySelect = false },
            };

            var target = new DefaultAuthority(authorityDatas) as IAuthority;

            Assert.IsTrue(target.CanSelect);
        }

        [TestMethod]
        public void CanInsert_true_DenyInsert_true()
        {
            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanInsert = true, DenyInsert = true },
            };

            var target = new DefaultAuthority(authorityDatas) as IAuthority;

            Assert.IsFalse(target.CanInsert);
        }

        [TestMethod]
        public void CanInsert_false_DenyInsert_null()
        {
            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanInsert = false, DenyInsert = null },
            };

            var target = new DefaultAuthority(authorityDatas) as IAuthority;

            Assert.IsFalse(target.CanInsert);
        }

        [TestMethod]
        public void CanUpdate_false_DenyUpdate_false()
        {
            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanUpdate = false, DenyUpdate = false },
            };

            var target = new DefaultAuthority(authorityDatas) as IAuthority;

            Assert.IsFalse(target.CanUpdate);
        }

        [TestMethod]
        public void CanUpdate_false_DenyUpdate_true()
        {
            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanUpdate = false, DenyUpdate = true },
            };

            var target = new DefaultAuthority(authorityDatas) as IAuthority;

            Assert.IsFalse(target.CanUpdate);
        }

        [TestMethod]
        public void CanDelete_null_DenyDelete_null()
        {
            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanDelete = null, DenyDelete = null },
            };

            var target = new DefaultAuthority(authorityDatas) as IAuthority;

            Assert.IsFalse(target.CanDelete);
        }

        [TestMethod]
        public void CanDelete_null_DenyDelete_false()
        {
            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanDelete = null, DenyDelete = false },
            };

            var target = new DefaultAuthority(authorityDatas) as IAuthority;

            Assert.IsFalse(target.CanDelete);
        }

        [TestMethod]
        public void CanParticular_null_DenyParticular_true()
        {
            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanParticular = null, DenyParticular = true },
            };

            var target = new DefaultAuthority(authorityDatas) as IAuthority;

            Assert.IsFalse(target.CanParticular);
        }
    }
}

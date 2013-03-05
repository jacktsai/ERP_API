using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yahoo.Data;
using Rhino.Mocks;
using System.Threading.Tasks;

namespace Yahoo.Services.Defaults
{
    // TODO: 有空時改用 SpecFlow 改寫。
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
        public void CanSelect_true_DenySelect_true()
        {
            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanSelect = true, DenySelect = true },
            };

            var target = new DefaultAuthority(authorityDatas) as IAuthority;

            Assert.IsFalse(target.CanSelect);
        }

        [TestMethod]
        public void CanSelect_false_DenySelect_null()
        {
            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanSelect = false, DenySelect = null },
            };

            var target = new DefaultAuthority(authorityDatas) as IAuthority;

            Assert.IsFalse(target.CanSelect);
        }

        [TestMethod]
        public void CanSelect_false_DenySelect_false()
        {
            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanSelect = false, DenySelect = false },
            };

            var target = new DefaultAuthority(authorityDatas) as IAuthority;

            Assert.IsFalse(target.CanSelect);
        }

        [TestMethod]
        public void CanSelect_false_DenySelect_true()
        {
            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanSelect = false, DenySelect = true },
            };

            var target = new DefaultAuthority(authorityDatas) as IAuthority;

            Assert.IsFalse(target.CanSelect);
        }

        [TestMethod]
        public void CanSelect_null_DenySelect_null()
        {
            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanSelect = null, DenySelect = null },
            };

            var target = new DefaultAuthority(authorityDatas) as IAuthority;

            Assert.IsFalse(target.CanSelect);
        }

        [TestMethod]
        public void CanSelect_null_DenySelect_false()
        {
            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanSelect = null, DenySelect = false },
            };

            var target = new DefaultAuthority(authorityDatas) as IAuthority;

            Assert.IsFalse(target.CanSelect);
        }

        [TestMethod]
        public void CanSelect_null_DenySelect_true()
        {
            var authorityDatas = new AuthorityData[]
            {
                new AuthorityData { CanSelect = null, DenySelect = true },
            };

            var target = new DefaultAuthority(authorityDatas) as IAuthority;

            Assert.IsFalse(target.CanSelect);
        }
    }
}

﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Resources;

namespace Yahoo.Data.Common.Resources
{
    [TestClass]
    public class ResourceTest
    {
        private class TestingDao : CommonDao
        {
            public TestingDao()
                : base("ResourceTest")
            {
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_dao_null()
        {
            new Resource(null);
        }

        [TestMethod]
        public void GetString()
        {
            var dao = new TestingDao();
            var target = new Resource(dao);
            var actual = target.GetString("TestFile.txt");

            Assert.AreEqual("This file is for Resource class testing.", actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetString_resourceName_null()
        {
            var dao = new TestingDao();
            var target = new Resource(dao);
            var actual = target.GetString(null);
        }

        [TestMethod]
        [ExpectedException(typeof(MissingManifestResourceException))]
        public void GetString_NotExists()
        {
            var dao = new TestingDao();
            var target = new Resource(dao);
            var actual = target.GetString("NotExists");
        }
    }
}

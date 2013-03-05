using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;
using System.Data.Common;

namespace ErpApi.Data.Common
{
    [TestClass]
    public class CommonDaoTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Ctor_connectionStringName_null()
        {
            try
            {
                var target = MockRepository.GenerateStub<CommonDao>(new object[] { null });
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(MissingConnectionStringSettingsException))]
        public void Ctor_connectionStringName_NotExists()
        {
            try
            {
                var target = MockRepository.GenerateStub<CommonDao>(new object[] { "NotExists" });
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Ctor_connectionStringName_InvalidProvider()
        {
            try
            {
                var target = MockRepository.GenerateStub<CommonDao>(new object[] { "InvalidProvider" });
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
        }

        [TestMethod]
        public void Ctor()
        {
            var target = MockRepository.GenerateStub<CommonDao>(new object[] { "CommonDaoTest" });

            Assert.IsNotNull(target.Settings);
            Assert.IsNotNull(target.Factory);
            Assert.IsNotNull(target.Resource);
        }
    }
}

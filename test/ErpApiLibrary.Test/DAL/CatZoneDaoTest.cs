using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ErpApi.DAL
{
    [TestClass]
    public class CatZoneDaoTest
    {
        [TestMethod]
        public void GetMany_ids_1_2_3_4_5()
        {
            ICatZoneDao target = new CatZoneDao();
            var actual = target.GetMany(new short[] { 1, 2, 3, 4, 5 });

            Assert.IsNotNull(actual);
            Assert.AreEqual(5, actual.Count());

            var zone1 = actual.Single(o => o.Id == 1);
            Assert.AreEqual(1, zone1.Id);
            Assert.AreEqual("百貨", zone1.Name);
            Assert.AreEqual(1, zone1.Sort);
            Assert.AreEqual("商品其他", zone1.PmDep);
            Assert.AreEqual(0, zone1.TypeId);
            Assert.AreEqual("一般區", zone1.TypeName);

            var zone2 = actual.Single(o => o.Id == 2);
            Assert.AreEqual(2, zone2.Id);
            Assert.AreEqual("書籍DVD", zone2.Name);
            Assert.AreEqual(2, zone2.Sort);
            Assert.AreEqual("生活量販TEAM", zone2.PmDep);
            Assert.AreEqual(0, zone2.TypeId);
            Assert.AreEqual("一般區", zone2.TypeName);

            var zone3 = actual.Single(o => o.Id == 3);
            Assert.AreEqual(3, zone3.Id);
            Assert.AreEqual("NB / PC", zone3.Name);
            Assert.AreEqual(10, zone3.Sort);
            Assert.AreEqual("電腦週邊TEAM", zone3.PmDep);
            Assert.AreEqual(0, zone1.TypeId);
            Assert.AreEqual("一般區", zone3.TypeName);

            var zone4 = actual.Single(o => o.Id == 4);
            Assert.AreEqual(4, zone4.Id);
            Assert.AreEqual("消費電子", zone4.Name);
            Assert.AreEqual(20, zone4.Sort);
            Assert.AreEqual("消電交通TEAM", zone4.PmDep);
            Assert.AreEqual(0, zone4.TypeId);
            Assert.AreEqual("一般區", zone4.TypeName);

            var zone5 = actual.Single(o => o.Id == 5);
            Assert.AreEqual(5, zone5.Id);
            Assert.AreEqual("視聽家電", zone5.Name);
            Assert.AreEqual(30, zone5.Sort);
            Assert.AreEqual("視聽家電TEAM", zone5.PmDep);
            Assert.AreEqual(1, zone5.TypeId);
            Assert.AreEqual("品牌區", zone5.TypeName);
        }
    }
}

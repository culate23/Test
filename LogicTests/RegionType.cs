using Microsoft.VisualStudio.TestTools.UnitTesting;
using Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Tests
{
    [TestClass()]
    public class RegionType
    {
        [TestMethod()]
        public void Create()
        {
            Model.RegionType regionType = new Model.RegionType();
            regionType.CapacityName = "Pruebas";
            regionType.IdCapacityType = 1;
            regionType.RegionName = "test";
            regionType.IdRegion = 2;
            regionType.Cost = 100;
            Logic.RegionType regionType2 = new Logic.RegionType();
            Assert.IsFalse(regionType2.Create(""));
        }

        [TestMethod()]
        public void Update()
        {
            Model.RegionType regionType = new Model.RegionType();
            regionType.CapacityName = "Pruebas";
            regionType.IdCapacityType = 1;
            regionType.RegionName = "test";
            regionType.IdRegion = 2;
            regionType.Cost = 100;
            Logic.RegionType regionType2 = new Logic.RegionType();
            Assert.IsFalse(regionType2.Update(""));
        }

        [TestMethod()]
        public void Delete()
        {
            Model.RegionType regionType = new Model.RegionType();
            regionType.CapacityName = "Pruebas";
            regionType.IdCapacityType = 1;
            regionType.RegionName = "test";
            regionType.IdRegion = 2;
            regionType.Cost = 100;
            Logic.RegionType regionType2 = new Logic.RegionType();
            Assert.IsFalse(regionType2.Delete(""));
        }

        [TestMethod()]
        public void GetRegions()
        {
            Model.RegionType regionType = new Model.RegionType();
            regionType.CapacityName = "Pruebas";
            regionType.IdCapacityType = 1;
            regionType.RegionName = "test";
            regionType.IdRegion = 2;
            regionType.Cost = 100;
            Logic.RegionType regionType2 = new Logic.RegionType();
            Assert.AreEqual(regionType2.GetRegions("").Count, 0);
        }
    }
}
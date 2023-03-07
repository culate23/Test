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
    public class Region
    {
        [TestMethod()]
        public void Create()
        {
            Model.Region region = new Model.Region();
            region.IdRegion = 1;
            region.RegionName = "Name";
            Logic.Region region1 = new Logic.Region();
            Assert.IsFalse(region1.Create(""));
        }

        [TestMethod()]
        public void Update()
        {
            Model.Region region = new Model.Region();
            region.IdRegion = 1;
            region.RegionName = "Name";
            Logic.Region region1 = new Logic.Region();
            Assert.IsFalse(region1.Update(""));
        }

        [TestMethod()]
        public void Delete()
        {
            Model.Region region = new Model.Region();
            region.IdRegion = 1;
            region.RegionName = "Name";
            Logic.Region region1 = new Logic.Region();
            Assert.IsFalse(region1.Delete(""));
        }

        [TestMethod()]
        public void GetRegions()
        {
            Model.Region region = new Model.Region();
            region.IdRegion = 1;
            region.RegionName = "Name";
            Logic.Region region1 = new Logic.Region();
            Assert.AreEqual(region1.GetRegions("").Count, 0);
        }

        [TestMethod()]
        public void countRegion()
        {
            Model.Region region = new Model.Region();
            region.IdRegion = 1;
            region.RegionName = "Name";
            Logic.Region region1 = new Logic.Region();
            Assert.AreEqual(region1.countRegion(""), 0);
        }
    }
}
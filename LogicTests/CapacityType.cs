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
    public class CapacityType
    {
        [TestMethod()]
        public void Create()
        {
            Model.CapacityType capacityType1 = new Model.CapacityType();
            capacityType1.NameCapacityType = "Prueba";
            capacityType1.IdCapacityType = 1;
            capacityType1.QuantityUnits = 1;
            Logic.CapacityType capacityType = new Logic.CapacityType(capacityType1);
            Assert.IsFalse(capacityType.Create(""));

        }

        [TestMethod()]
        public void Update()
        {
            Model.CapacityType capacityType1 = new Model.CapacityType();
            capacityType1.NameCapacityType = "Prueba";
            capacityType1.IdCapacityType = 1;
            capacityType1.QuantityUnits = 2;
            Logic.CapacityType capacityType = new Logic.CapacityType(capacityType1);
            Assert.IsFalse(capacityType.Update(""));
        }

        [TestMethod()]
        public void Delete()
        {
            Model.CapacityType capacityType1 = new Model.CapacityType();
            capacityType1.NameCapacityType = "Prueba";
            capacityType1.IdCapacityType = 1;
            capacityType1.QuantityUnits = 2;
            Logic.CapacityType capacityType = new Logic.CapacityType(capacityType1);
            Assert.IsFalse(capacityType.Delete(""));
        }

        [TestMethod()]
        public void GetcapacityTypes()
        {
            Model.CapacityType capacityType1 = new Model.CapacityType();
            capacityType1.NameCapacityType = "Prueba";
            capacityType1.IdCapacityType = 1;
            capacityType1.QuantityUnits = 2;
            Logic.CapacityType capacityType = new Logic.CapacityType(capacityType1);
            Assert.AreEqual(capacityType.GetcapacityTypes("").Count, 0);
        }

        [TestMethod()]
        public void countCapatyType()
        {
            Model.CapacityType capacityType1 = new Model.CapacityType();
            capacityType1.NameCapacityType = "Prueba";
            capacityType1.IdCapacityType = 1;
            capacityType1.QuantityUnits = 2;
            Logic.CapacityType capacityType = new Logic.CapacityType(capacityType1);
            Assert.AreEqual(capacityType.countCapatyType("", 1), 0);
        }
    }
}
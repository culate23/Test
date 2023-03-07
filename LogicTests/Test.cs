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
    public class Test
    {
        [TestMethod()]
        public void calcularCosto()
        {
            Logic.Test calc = new Logic.Test();

            Assert.AreEqual(calc.calcularCosto(10, 1).Count(), 0);
        }
    }
}
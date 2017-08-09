using guisfits.HealthTrack.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace guisfits.HealthTrack.Domain.Tests.Models
{
    [TestClass]
    public class PesoTest
    {
        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void ValorKgTest()
        {
            var peso1 = new Peso(84);
            var peso2 = new Peso(-2); //Gera Exception

            Assert.IsNotNull(peso1.ValorKg);
            Assert.AreNotEqual(-2, peso2.ValorKg);
        }

        [TestMethod]
        public void setValorKgTest()
        {
            var peso = new Peso(85, DateTime.Now);
            peso.ValorKg = 80;

            Assert.AreEqual(80, peso.ValorKg);
        }

        [TestMethod]
        public void PesoEqualityTest()
        {
            var peso1 = new Peso(80, new DateTime(2017, 12, 01));
            var peso2 = new Peso(80, new DateTime(2017, 12, 02));
            var peso3 = peso1;

            Assert.IsTrue(peso1 != peso2);
            Assert.IsTrue(peso1 == peso3);
            Assert.IsTrue(peso1.Equals(peso3));
            Assert.IsFalse(object.Equals(peso1, peso2));
            Assert.IsTrue(object.Equals(peso1, peso3));
        }
    }
}

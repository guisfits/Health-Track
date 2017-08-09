using guisfits.HealthTrack.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace guisfits.HealthTrack.Domain.Tests.Models
{
    [TestClass]
    public class PressaoArterialTest
    {
        [TestMethod]
        public void getStatusTest()
        {
            var pa = new PressaoArterial(130, 85, new DateTime(2017, 08, 02));
            var pa2 = new PressaoArterial(110, 75, new DateTime(2017, 08, 02));
            var pa3 = new PressaoArterial(150, 100, new DateTime(2017, 08, 02));
            var pa4 = new PressaoArterial(170, 60, new DateTime(2017, 08, 02));

            Assert.AreEqual("Normal", pa.Status);
            Assert.AreEqual("Abaixo do normal", pa2.Status);
            Assert.AreEqual("Elevada", pa3.Status);
            Assert.AreEqual("ERRO", pa4.Status);
        }
    }
}

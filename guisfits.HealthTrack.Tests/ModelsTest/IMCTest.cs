using guisfits.HealthTrack.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace guisfits.HealthTrack.ModelsTest
{
    [TestClass]
    public class IMCTest
    {
        [TestMethod]
        public void getValorTest()
        {
            var imc1 = new IMC(83, 1.83);
            var imc2 = new IMC(120, 1.65);
            var imc3 = new IMC(60, 1.90);

            Assert.AreEqual(24.78, imc1.Valor, 0.01);
            Assert.AreEqual(44.07, imc2.Valor, 0.01);
            Assert.AreEqual(16.62, imc3.Valor, 0.01);
        }

        [TestMethod]
        public void getStatusTest()
        {
            var imc1 = new IMC(83, 1.83);
            var imc2 = new IMC(120, 1.65);
            var imc3 = new IMC(60, 1.90);

            Assert.AreEqual("Peso normal", imc1.Status);
            Assert.AreEqual("Obesidade mórbida", imc2.Status);
            Assert.AreEqual("Muito abaixo do peso", imc3.Status);
        }

        [TestMethod]
        public void setValorTest()
        {
            var imc1 = new IMC(83, 1.83);
            Assert.AreEqual(24.78, imc1.Valor, 0.01);
            Assert.AreEqual("Peso normal", imc1.Status);

            imc1.setValor(120, 1.65);
            Assert.AreEqual(44.07, imc1.Valor, 0.01);
            Assert.AreEqual("Obesidade mórbida", imc1.Status);
        }
    }
}

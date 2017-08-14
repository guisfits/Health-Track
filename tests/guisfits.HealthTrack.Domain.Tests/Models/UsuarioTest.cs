using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace guisfits.HealthTrack.Domain.Tests.Models
{
    [TestClass]
    public class UsuarioTest
    {
        [TestMethod]
        public void getIMCTest()
        {
            var usuario = new Usuario("Guilherme", "Camargo", "guisfits@hotmail.com", TipoSexo.Masculino, 1.83, new DateTime(1993, 12, 23), 84.5);
            IMC imc = usuario.getIMC();
            Assert.AreEqual(25.23, imc.Valor, 0.01);
            Assert.AreEqual("Acima do peso", imc.Status);
        }
    }
}

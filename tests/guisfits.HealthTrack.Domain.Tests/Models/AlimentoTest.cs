using guisfits.HealthTrack.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace guisfits.HealthTrack.Domain.Tests.Models
{
    [TestClass]
    public class AlimentoTest
    {
        [TestMethod]
        public void AlimentacaoObjetoTest()
        {
            var alimentacao = new Alimento(TipoAlimento.CafeDaManha, "Pão com mortadela", 100, DateTime.Now);
            Assert.IsNotNull(alimentacao);
        }
    }
}

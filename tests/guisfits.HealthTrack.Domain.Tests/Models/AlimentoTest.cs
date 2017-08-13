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
            var alimentacao = new Alimento(TipoAlimento.CafeDaManha, 100, DateTime.Now, "File de frango");
            Assert.IsNotNull(alimentacao);
        }
    }
}

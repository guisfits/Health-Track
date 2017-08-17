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
            var alimentacao = new Alimento()
            {
                Tipo = TipoAlimento.CafeDaManha,
                Calorias = 100,
                DataHora = DateTime.Now,
                Descricao = "File de frango"
            };
            Assert.IsNotNull(alimentacao);
        }
    }
}

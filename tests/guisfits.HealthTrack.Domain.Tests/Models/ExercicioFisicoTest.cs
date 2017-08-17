using guisfits.HealthTrack.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace guisfits.HealthTrack.Domain.Tests.Models
{
    [TestClass]
    public class ExercicioFisicoTest
    {
        [TestMethod]
        public void ExercicioFisicoObjetoTest()
        {
            var ef = new ExercicioFisico()
            {
                Tipo = TipoExercicio.Musculacao,
                Calorias = 200,
                DataHora = DateTime.Now,
                Descricao = "Serie A",
            };

            Assert.IsNotNull(ef);
        }
    }
}

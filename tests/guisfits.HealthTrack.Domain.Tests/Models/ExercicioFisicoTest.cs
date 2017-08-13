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
            var ef = new ExercicioFisico(TipoExercicio.Musculacao, 200, DateTime.Now);

            Assert.IsNotNull(ef);
        }

        [TestMethod]
        public void ExercicioFisicoObjetoTestWithDescricao()
        {
            var ef = new ExercicioFisico(TipoExercicio.Musculacao, 200, DateTime.Now, "Série A");

            Assert.IsNotNull(ef);
        }
    }
}

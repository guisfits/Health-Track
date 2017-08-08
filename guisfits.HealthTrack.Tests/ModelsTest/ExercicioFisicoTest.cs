using guisfits.HealthTrack.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace guisfits.HealthTrack.ModelsTest
{
    [TestClass]
    public class ExercicioFisicoTest
    {
        [TestMethod]
        public void ExercicioFisicoObjetoTest()
        {
            var ef = new ExercicioFisico(TipoExercicio.Musculacao, "Série A", 200, DateTime.Now);

            Assert.IsNotNull(ef);
        }
    }
}

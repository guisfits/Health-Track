using guisfits.HealthTrack.Domain.Specification.Usuario;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace guisfits.HealthTrack.Domain.Tests.Specification.Usuario
{
    [TestClass]
    public class UsuarioDevePossuirPesoPossivelSpecificationTest
    {
        [TestMethod]
        public void PesoSpecification_IsSatisfiedBy_True()
        {
            //Arrange
            var usuario = new Domain.Models.Usuario()
            {
                PesoAtual = 84
            };

            //Act
            var result = new UsuarioDevePossuirPesoPossivelSpecification().IsSatisfiedBy(usuario);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PesoSpecification_IsSatisfiedBy_false()
        {
            //Arrange
            var usuario = new Domain.Models.Usuario()
            {
                PesoAtual = -5
            };
            var usuario2 = new Domain.Models.Usuario()
            {
                PesoAtual = 5500
            };

            //Act
            var result = new UsuarioDevePossuirPesoPossivelSpecification().IsSatisfiedBy(usuario);
            var result2 = new UsuarioDevePossuirPesoPossivelSpecification().IsSatisfiedBy(usuario2);

            //Assert
            Assert.IsFalse(result);
            Assert.IsFalse(result2);
        }
    }
}

using guisfits.HealthTrack.Domain.Specification.Usuario;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace guisfits.HealthTrack.Domain.Tests.Specification.Usuario
{
    [TestClass]
    public class UsuarioDevePossuirAlturaPossivelSpecificationTest
    {
        [TestMethod]
        public void AlturaSpecification_IsSatisfiedBy_True()
        {
            //Arrange
            var usuario = new Domain.Models.Usuario()
            {
                Altura = 183
            };

            //Act
            var result = new UsuarioDevePossuirAlturaPossivelSpecification().IsSatisfiedBy(usuario);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void AlturaSpecification_IsSatisfiedBy_False()
        {
            //Arrange
            var usuario = new Domain.Models.Usuario()
            {
                Altura = 1
            };
            var usuario2 = new Domain.Models.Usuario()
            {
                Altura = 5000
            };

            //Act
            var result = new UsuarioDevePossuirAlturaPossivelSpecification().IsSatisfiedBy(usuario);
            var result2 = new UsuarioDevePossuirAlturaPossivelSpecification().IsSatisfiedBy(usuario2);

            //Assert
            Assert.IsFalse(result);
            Assert.IsFalse(result2);
        }
    }
}

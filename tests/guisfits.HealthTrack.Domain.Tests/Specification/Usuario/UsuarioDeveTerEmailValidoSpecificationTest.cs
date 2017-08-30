using Microsoft.VisualStudio.TestTools.UnitTesting;
using guisfits.HealthTrack.Domain.Specification.Usuario;

namespace guisfits.HealthTrack.Domain.Tests.Specification.Usuario
{
    [TestClass]
    public class UsuarioDeveTerEmailValidoSpecificationTest
    {
        [TestMethod]
        public void EmailSpecification_IsSatisfiedBy_True()
        {
            //Arrange
            var usuario = new Domain.Models.Usuario()
            {
                Email = "guisfits@hotmail.com"
            };

            //Act
            var result = new UsuarioDeveTerEmailValidoSpecification().IsSatisfiedBy(usuario);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void EmailSpecification_IsSatisfiedBy_False()
        {
            //Arrange
            var usuario = new Domain.Models.Usuario()
            {
                Email = "guisfitshotmailcom"
            };

            //Act
            var result = new UsuarioDeveTerEmailValidoSpecification().IsSatisfiedBy(usuario);

            //Assert
            Assert.IsFalse(result);
        }
    }
}

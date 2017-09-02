using guisfits.HealthTrack.Domain.Specification.Usuario;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace guisfits.HealthTrack.Domain.Tests.Specification.Usuario
{
    [TestClass]
    public class UsuarioDeveTerNomeValidoSpecificationTest
    {
        [TestMethod]
        public void NomeSobrenomeSpecification_IsSatisfiedBy_True()
        {
            //Arrange
            var usuario = new Domain.Models.Usuario()
            {
                Nome = "Guilherme",
                Sobrenome = "Camargo Silva"
            };

            //Act
            var result = new UsuarioDeveTerNomeValidoSpecification().IsSatisfiedBy(usuario);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NomeSobrenomeSpecification_IsSatisfiedBy_False()
        {
            //Arrange
            var usuario1 = new Domain.Models.Usuario()
            {
                Nome = "",
                Sobrenome = ""
            };
            var usuario2 = new Domain.Models.Usuario()
            {
                Nome = "123",
                Sobrenome = "123"
            };
            var usuario3 = new Domain.Models.Usuario()
            {
                Nome = "#$%",
                Sobrenome = "¨$%#_-+="
            };

            //Act
            var result1 = new UsuarioDeveTerNomeValidoSpecification().IsSatisfiedBy(usuario1);
            var result2 = new UsuarioDeveTerNomeValidoSpecification().IsSatisfiedBy(usuario2);
            var result3 = new UsuarioDeveTerNomeValidoSpecification().IsSatisfiedBy(usuario3);

            //Assert
            Assert.IsFalse(result1);
            Assert.IsFalse(result2);
            Assert.IsFalse(result3);
        }
    }
}

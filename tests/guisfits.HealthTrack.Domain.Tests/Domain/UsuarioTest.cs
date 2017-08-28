using System.Linq;
using guisfits.HealthTrack.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace guisfits.HealthTrack.Domain.Tests.Domain
{
    [TestClass]
    public class UsuarioTest
    {
        //AAA = Arrange, Act, Assert
        [TestMethod]
        public void Usuario_EhValido_True()
        {
            //Arrange
            var usuario = new Usuario()
            {
                Email = "fulano@teste.com"
            };

            //Act
            bool result = usuario.EhValido();

            //Assert
            Assert.IsTrue(result);
            Assert.IsFalse(usuario.ValidationResult.Erros.Any(e => e.Message == "O E-mail está em formato incorreto"));
        }

        [TestMethod]
        public void Usuario_EhValido_False()
        {
            //Arrange
            var usuario = new Usuario()
            {
                Email = "blablabla"
            };

            //Act
            bool result = usuario.EhValido();

            //Assert
            Assert.IsFalse(result);
            Assert.IsTrue(usuario.ValidationResult.Erros.Any(e => e.Message == "O E-mail está em formato incorreto"));
        }
    }
}
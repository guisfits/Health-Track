using System;
using System.Linq;
using guisfits.HealthTrack.Domain.Validation.Usuario;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace guisfits.HealthTrack.Domain.Tests.Validation.Usuario
{
    [TestClass]
    public class UsuarioEstaConsistenteValidationTest
    {
        [TestMethod]
        public void UsuarioConsistente_Validate_True()
        {
            //Arrange
            var usuario = new Domain.Models.Usuario()
            {
                Nascimento = new DateTime(1993, 12, 23),
                PesoAtual = 84,
                Altura = 183
            };

            //Act
            var result = new UsuarioEstaConsistenteValidation().Validate(usuario).IsValid;

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void UsuarioConsistente_Validate_False()
        {
            //Arrange
            var usuario = new Domain.Models.Usuario()
            {
                Nascimento = DateTime.Now,
                PesoAtual = -1,
                Altura = 5000
            };

            //Act
            var result = new UsuarioEstaConsistenteValidation().Validate(usuario).IsValid;

            //Assert
            Assert.IsFalse(result);
            //Assert.IsTrue(usuario.ValidationResult.Erros.Any(e => e.Message == "O usuário deve ser maior de idade"));
            //Assert.IsTrue(usuario.ValidationResult.Erros.Any(e => e.Message == "Altura deve ser entre 70 a 299 cm"));
            //Assert.IsTrue(usuario.ValidationResult.Erros.Any(e => e.Message == "Peso deve ser menor que 300 kg"));
        }
    }
}

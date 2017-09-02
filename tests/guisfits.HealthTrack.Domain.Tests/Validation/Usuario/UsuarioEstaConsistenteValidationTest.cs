using System;
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
                Nome = "Guilherme",
                Sobrenome = "Camargo Silva",
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
                Nome = "#$%",
                Sobrenome = "",
                Nascimento = DateTime.Now,
                PesoAtual = -1,
                Altura = 5000
            };

            //Act
            var result = new UsuarioEstaConsistenteValidation().Validate(usuario).IsValid;

            //Assert
            Assert.IsFalse(result);
        }
    }
}

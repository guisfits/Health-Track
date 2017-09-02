using System;
using System.Linq;
using guisfits.HealthTrack.Domain.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace guisfits.HealthTrack.Domain.Tests.Models
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
                Nascimento = new DateTime(1993,12,23),
                PesoAtual = 84,
                Altura = 183
            };

            //Act
            bool result = usuario.EhValido();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void Usuario_EhValido_False()
        {
            //Arrange
            var usuario = new Usuario()
            {
                Nascimento = DateTime.Now,
                PesoAtual = 0,
                Altura = 4000
            };

            //Act
            bool result = usuario.EhValido();

            //Assert
            Assert.IsFalse(result);
            Assert.IsTrue(usuario.ValidationResult.Erros.Any(e => e.Message == "O usuário deve ser maior de idade"));
            Assert.IsTrue(usuario.ValidationResult.Erros.Any(e => e.Message == "Altura deve ser entre 70 a 299 cm"));
            Assert.IsTrue(usuario.ValidationResult.Erros.Any(e => e.Message == "Peso deve ser menor que 300 kg"));
        }
    }
}
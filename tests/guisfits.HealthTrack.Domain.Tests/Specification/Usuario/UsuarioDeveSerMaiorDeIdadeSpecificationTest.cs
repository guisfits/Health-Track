using System;
using guisfits.HealthTrack.Domain.Specification.Usuario;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace guisfits.HealthTrack.Domain.Tests.Specification.Usuario
{
    [TestClass]
    public class UsuarioDeveSerMaiorDeIdadeSpecificationTest
    {
        [TestMethod]
        public void NascimentoSpecification_IsSatisfiedBy_True()
        {
            //Arrange
            var usuario = new Domain.Models.Usuario()
            {
                Nascimento = new DateTime(1993, 12, 23)
            };

            //Act
            bool result = new UsuarioDeveSerMaiorDeIdadeSpecification().IsSatisfiedBy(usuario);

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void NascimentoSpecification_IsSatisfiedBy_False()
        {
            //Arrange
            var usuario = new Domain.Models.Usuario()
            {
                Nascimento = DateTime.Now
            };

            //Act
            var result = new UsuarioDeveSerMaiorDeIdadeSpecification().IsSatisfiedBy(usuario);

            //Assert
            Assert.IsFalse(result);
        }
    }
}

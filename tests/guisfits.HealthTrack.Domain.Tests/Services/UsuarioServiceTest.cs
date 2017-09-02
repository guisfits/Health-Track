using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using Rhino.Mocks;

namespace guisfits.HealthTrack.Domain.Tests.Services
{
    [TestClass]
    public class UsuarioServiceTest
    {
        [TestMethod]
        public void UsuarioService_Adicionar_IsValid()
        {
            //Arrange
            var usuario = new Usuario()
            {
                Nome = "Guilherme",
                Sobrenome = "Camargo Silva",
                Nascimento = new DateTime(1993, 12, 23),
                Altura = 183,
                PesoAtual = 84
            };

            //Act
            usuario.EhValido();
            var repo = MockRepository.GenerateStub<IUsuarioRepository>();
            repo.Stub(s => s.Adicionar(usuario)).Return(usuario);

            var resultado = new Domain.Services.UsuarioService(repo).Adicionar(usuario);

            //Assert
            Assert.IsTrue(usuario.ValidationResult.IsValid);
        }
    }
}

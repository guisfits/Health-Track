using Microsoft.VisualStudio.TestTools.UnitTesting;
using guisfits.HealthTrack.Domain.Models;
using Rhino.Mocks;
using guisfits.HealthTrack.Domain.Interfaces.Repository;

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
                Email = "guisfits@hotmail.com"
            };

            //Act
            usuario.EhValido();
            var repo = MockRepository.GenerateStub<IUsuarioRepository>();
            repo.Stub(s => s.Adicionar(usuario)).Return(usuario);
            repo.Stub(s => s.ObterUsuarioUnico(usuario)).Return(null);

            var resultado = new Domain.Services.UsuarioService(repo).Adicionar(usuario);

            //Assert
            Assert.IsTrue(usuario.ValidationResult.IsValid);
        }
    }
}

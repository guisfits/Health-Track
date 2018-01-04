using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Core.Interfaces.Repository;
using HealthTrack.Domain.Enums;
using HealthTrack.Domain.Models;
using Moq;
using NUnit.Framework;

namespace HealthTrack.Data.Tests.Repository
{
    [TestFixture]
    public class RepositoryTest
    {
        #region SetUp

        private Usuario usuario1;
        private Usuario usuario2;
        private Mock<IUsuarioRepository> mock;
        private List<Usuario> list;
        
        [SetUp]
        public void Init()
        {
            usuario1 = new Usuario
            {
                Id = Guid.NewGuid().ToString(),
                Nome = "Guilherme",
                Sobrenome = "Camargo Silva",
                Nascimento = new DateTime(1993, 12, 23),
                Sexo = Sexo.Masculino,
                Altura = 1.83f
            };

            usuario2 = new Usuario
            {
                Id = Guid.NewGuid().ToString(),
                Nome = "Juliana",
                Sobrenome = "Taveira Benfica",
                Nascimento = new DateTime(1997, 04, 13),
                Sexo = Sexo.Feminino,
                Altura = 1.65f
            };

            mock = new Mock<IUsuarioRepository>();

            list = new List<Usuario>();
            list.Add(usuario1);
            list.Add(usuario2);
        }

        [TearDown]
        public void Finalize()
        {
            usuario1 = null;
            mock = null;
        }

        #endregion

        [Test]
        public void GivenId_WhenGeCalled_ExpectEntityObject()
        {
            mock.Setup(repo => repo.Get(usuario1.Id)).Returns(usuario1);

            var user = mock.Object.Get(usuario1.Id);

            Assert.That(user, Is.Not.Null);
            Assert.That(user.Nome, Is.EqualTo("Guilherme"));
        }

        [Test]
        public void WhenGetAllCalled_ExpectListOfEntityObjects()
        {
            var list = new Collection<Usuario>();
            list.Add(usuario1);
            mock.Setup(repo => repo.GetAll()).Returns(list);

            var users = mock.Object.GetAll();
            var user = users.FirstOrDefault();

            Assert.That(users.Count(), Is.GreaterThan(0));
            Assert.That(user, Is.EqualTo(usuario1));
        }

        [Test]
        public void GivenLambdaExpression_WhenFindCalled_ExpectListOfCorrespondingObjects()
        {
            mock.Setup(repo => repo.Find(c => c.Nome == "Guilherme"))
                .Returns(list.Where(c => c.Nome == "Guilherme"));

            var users = mock.Object.Find(c => c.Nome == "Guilherme");
            var user = users.FirstOrDefault();

            Assert.That(users.Count(), Is.GreaterThan(0));
            Assert.That(user, Is.EqualTo(usuario1));
        }

        [Test]
        public void GivenPageAndSize_WhenPaginationCalled_ExpectListOfCorrespondingObjects()
        {
            var page = 1;
            var size = 10;
            mock.Setup(repo => repo.Pagination(page, size))
                .Returns(list.Skip((page - 1) * size).Take(size));

            var users = mock.Object.Pagination(page, size);

            Assert.That(users.Count(), Is.EqualTo(2));
        }

        [Test]
        public void GivenEntityObject_WhenAddCalled_ExpectEntityObjectWithNewId()
        {
            usuario1.Id = null;
            var usuarioAdded = usuario1;
            usuarioAdded.Id = Guid.NewGuid().ToString();
            mock.Setup(repo => repo.Add(usuario1))
                .Returns(usuarioAdded);

            var addCheck = mock.Object.Add(usuario1);

            Assert.That(addCheck.Id, Is.Not.Null);
        }
    }
}

using System;
using System.Linq;
using HealthTrack.Domain.Enums;
using HealthTrack.Domain.Models;
using NUnit.Framework;

namespace HealthTrack.Domain.Tests.Validations
{
    [TestFixture]
    public class AlimentoValidationTest
    {
        private Alimento alimento;

        [SetUp]
        public void Before()
        {
            alimento = new Alimento();
        }

        [TearDown]
        public void After()
        {
            alimento = null;
        }

        [Test]
        [Category("Validação")]
        public void Validacao_DataDeveSerMenorQueDataAtual_False()
        {
            alimento.DataHora = DateTime.Now.AddDays(1);

            var validation = alimento.Validar();
            var result = validation.IsValid;
            var erro = validation.Errors.First(c => !c.ErrorMessage.Contains("Tipo de Alimento"));

            Assert.That(result, Is.False);
            Assert.That(erro.ErrorMessage, Is.EqualTo("Data deve ser menor que a data atual"));
        }

        [Test]
        [Category("Validação")]
        public void Validacao_DataDeveSerMenorQueDataAtual_True()
        {
            alimento.DataHora = DateTime.Now.AddDays(-1);
            alimento.Tipo = AlimentoTipo.Fruta;

            var validation = alimento.Validar();
            var result = validation.IsValid;

            Assert.That(result, Is.True);
        }

        [Test]
        [Category("Validação")]
        public void Validacao_DataNaoDeveTerMaisDeUmAno_False()
        {
            alimento.DataHora = DateTime.Now.AddYears(-2);

            var validation = alimento.Validar();
            var result = validation.IsValid;
            var erro = validation.Errors.First(c => !c.ErrorMessage.Contains("Tipo de Alimento"));

            Assert.That(result, Is.False);
            Assert.That(erro.ErrorMessage, Is.EqualTo($"Ano deve ser maior que {DateTime.Now.AddYears(-1).Year}"));
        }

        [Test]
        [Category("Validação")]
        public void Validacao_DataNaoDeveTerMaisDeUmAno_True()
        {
            alimento.DataHora = DateTime.Now.AddMonths(-11);
            alimento.Tipo = AlimentoTipo.Fruta;

            var validation = alimento.Validar();
            var result = validation.IsValid;

            Assert.That(result, Is.True);
        }

        [Test]
        [Category("Validação")]
        public void Validacao_TipoNaoPorSerNulo_IsNull()
        {
            Assert.That(alimento.Tipo, Is.Null);
        }

        [Test]
        [Category("Validação")]
        public void Validacao_TipoNaoPorSerNulo_IsNotNull()
        {
            alimento.Tipo = AlimentoTipo.Fruta;
            Assert.That(alimento.Tipo, Is.Not.Null);
        }
    }
}

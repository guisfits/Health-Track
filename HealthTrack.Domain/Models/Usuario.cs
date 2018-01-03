using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using HealthTrack.Domain.Enums;
using HealthTrack.Domain.Validation;

namespace HealthTrack.Domain.Models
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public float Altura { get; set; }
        public DateTime Nascimento { get; set; }
        public Sexo Sexo { get; set; }
        public string ImagemPath { get; set; }

        public virtual IList<Peso> Pesos { get; set; }
        public virtual IList<Alimento> Alimentos { get; set; }
        public virtual IList<ExercicioFisico> ExerciciosFisicos { get; set; }
        public virtual IList<PressaoArterial> PressoesArteriais { get; set; }

        public Imc Imc { get; set; }
        private readonly UsuarioValidation _validation;

        public Usuario()
        {
            Alimentos = new List<Alimento>();
            ExerciciosFisicos = new List<ExercicioFisico>();
            PressoesArteriais = new List<PressaoArterial>();
            Pesos = new List<Peso>();
            _validation = new UsuarioValidation();
            Imc = new Imc(PesoAtual(), Altura);
        }

        public int IdadeAtual()
        {
            var result = DateTime.Now.Year - Nascimento.Year;
            if (Nascimento >= DateTime.Now.AddYears(-result)) result--;
            return result;
        }

        public float PesoAtual()
        {
            return Pesos.Count > 0 ? Pesos.OrderByDescending(c => c.DataHora).First().ValorPeso : 0;
        }

        public Imc GetImc()
        {
            return new Imc(PesoAtual(), Altura);
        }

        public override ValidationResult Validar()
        {
            return _validation.Validate(this);
        }
    }
}
using guisfits.HealthTrack.Domain.Helpers;
using guisfits.HealthTrack.Domain.Validation.Usuario;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace guisfits.HealthTrack.Domain.Models
{
    public enum TipoSexo
    {
        Masculino,
        Feminino
    }

    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public double Altura { get; set; }
        public DateTime Nascimento { get; set; }
        public bool Excluido { get; private set; } = false;
        public string IdentityId { get; set; }
        public Imc Imc { get; set; }

        public TipoSexo Sexo { get; set; }
        [Column("Sexo")]
        public string SexoString
        {
            get => Sexo.ToString();
            set => Sexo = Sexo = value.ParceToEnum<TipoSexo>();
        }

        public int IdadeAtual
        {
            get
            {
                var result = DateTime.Now.Year - Nascimento.Year;
                if (Nascimento > DateTime.Now.AddYears(-result)) result--;
                return result;
            }
        }

        private double _pesoAtual;
        public double PesoAtual
        {
            get => Pesos.Count > 0 ? Pesos[Pesos.Count - 1].PesoValue : 0;
            set
            {
                _pesoAtual = value;
                Pesos.Add(new Peso(_pesoAtual));
            }
        }

        public virtual IList<Peso> Pesos { get; set; }
        public virtual ICollection<Alimento> Alimentos { get; set; }
        public virtual ICollection<ExercicioFisico> ExerciciosFisicos { get; set; }
        public virtual ICollection<PressaoArterial> PressoesArteriais { get; set; }

        public Usuario()
        {
            Alimentos = new List<Alimento>();
            ExerciciosFisicos = new List<ExercicioFisico>();
            PressoesArteriais = new List<PressaoArterial>();
            Pesos = new List<Peso>();
            Imc = new Imc(_pesoAtual, Altura);
        }

        public override bool EhValido()
        {
            ValidationResult = new UsuarioEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid && Excluido == false;
        }

        public void Excluir()
        {
            Excluido = true;
        }
    }
}
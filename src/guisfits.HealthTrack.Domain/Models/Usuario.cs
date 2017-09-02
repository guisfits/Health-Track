using System;
using System.Collections.Generic;
using guisfits.HealthTrack.Domain.Validation.Usuario;

namespace guisfits.HealthTrack.Domain.Models
{
    public enum TipoSexo { Masculino, Feminino }

    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public TipoSexo Sexo { get; set; }
        public double Altura { get; set; }
        public DateTime Nascimento { get; set; }
        public bool Excluido { get; private set; } = false;
        public string IdentityId { get; set; }

        private double _pesoAtual;
        public double PesoAtual
        {
            get
            {
                _pesoAtual = Pesos.Count > 0 ? Pesos[Pesos.Count - 1].ValorKg : 0;
                return _pesoAtual;
            }
            set
            {
                if (!(value > 0)) return;

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
        }

        public string NomeCompleto()
        {
            return $"{Nome} {Sobrenome}";
        }

        public Imc GetImc()
        {
            return new Imc(this._pesoAtual, this.Altura);
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
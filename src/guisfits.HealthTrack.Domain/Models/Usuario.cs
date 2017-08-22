using guisfits.HealthTrack.Domain.Services;
using System;
using System.Collections.Generic;

namespace guisfits.HealthTrack.Domain.Models
{
    public enum TipoSexo { Masculino, Feminino }

    public class Usuario : Entity
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public TipoSexo Sexo { get; set; }
        public double AlturaMetros { get; set; }
        public DateTime Nascimento { get; set; }

        private double _pesoAtual;
        public double PesoAtual
        {
            get
            {
                _pesoAtual = PesosKg.Count > 0 ? PesosKg[PesosKg.Count - 1].ValorKg : 0;
                return _pesoAtual;
            }
            set
            {
                if (!(value > 0)) return;

                _pesoAtual = value;
                PesosKg.Add(new Peso(_pesoAtual));
            }
        }

        public virtual IList<Peso> PesosKg { get; set; }
        public virtual ICollection<Alimento> Alimentos { get; set; }
        public virtual ICollection<ExercicioFisico> ExerciciosFisicos { get; set; }
        public virtual ICollection<PressaoArterial> PressoesArteriais { get; set; }

        public Usuario()
        {
            Alimentos = new List<Alimento>();
            ExerciciosFisicos = new List<ExercicioFisico>();
            PressoesArteriais = new List<PressaoArterial>();
            PesosKg = new List<Peso>();
        }

        public string NomeCompleto()
        {
            return $"{Nome} {Sobrenome}";
        }

        public IMC GetImc()
        {
            return new IMC(this._pesoAtual, this.AlturaMetros);
        }

        protected override bool EhValido()
        {
            //Esperando pelas classes de validação
            return true;
        }
    }
}
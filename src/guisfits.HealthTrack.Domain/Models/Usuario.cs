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
                if (PesosKg.Count > 0)
                    this._pesoAtual = this.PesosKg[PesosKg.Count - 1].ValorKg;
                else
                    this._pesoAtual = 0;

                return this._pesoAtual;
            }
            set
            {
                if (value > 0)
                {
                    _pesoAtual = value;
                    this.PesosKg.Add(new Peso(_pesoAtual));
                }
            }
        }

        public virtual IList<Peso> PesosKg { get; set; }
        public virtual ICollection<Alimento> Alimentos { get; set; }
        public virtual ICollection<ExercicioFisico> ExerciciosFisicos { get; set; }
        public virtual ICollection<PressaoArterial> PressoesArteriais { get; set; }

        public Usuario(string Nome, string Sobrenome, string Email, TipoSexo Sexo, double AlturaMetros, DateTime Nascimento, double PesoKg)
        {
            this.Nome = Nome;
            this.Sobrenome = Sobrenome;
            this.Email = Email;
            this.Sexo = Sexo;
            this.AlturaMetros = AlturaMetros;
            this.Nascimento = Nascimento;

            Alimentos = new List<Alimento>();
            ExerciciosFisicos = new List<ExercicioFisico>();
            PressoesArteriais = new List<PressaoArterial>();
            PesosKg = new List<Peso>();
            PesosKg.Add(new Peso(PesoKg));
        }

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

        public IMC getIMC()
        {
            return new IMC(this._pesoAtual, this.AlturaMetros);
        }

        protected override bool EhValido()
        {
            //fazer uma melhor avaliação
                
            return true;
        }
    }
}
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
        public TipoSexo Sexo { get; set; }
        public double AlturaMetros { get; set; }
        public DateTime Nascimento { get; set; }

        public virtual List<Peso> PesosKg { get; set; }
        public virtual ICollection<Alimento> Alimentos { get; set; }
        public virtual ICollection<ExercicioFisico> ExerciciosFisicos { get; set; }
        public virtual ICollection<PressaoArterial> PressoesArteriais { get; set; }

        public Usuario(string Nome, string Sobrenome, TipoSexo Sexo, double AlturaMetros, DateTime Nascimento, double PesoKg)
        {
            this.Nome = Nome;
            this.Sobrenome = Sobrenome;
            this.Sexo = Sexo;
            this.AlturaMetros = AlturaMetros;
            this.Nascimento = Nascimento;

            PesosKg = new List<Peso>();
            PesosKg.Add(new Peso(PesoKg));

            Alimentos = new List<Alimento>();
            ExerciciosFisicos = new List<ExercicioFisico>();
            PressoesArteriais = new List<PressaoArterial>();
        }

        public string NomeCompleto()
        {
            return $"{Nome} {Sobrenome}";
        }

        public IMC getIMC()
        {
            if (PesosKg.Count > 0)
            {
                var indexPeso = PesosKg.Count;
                var peso = this.PesosKg[indexPeso - 1];
                var imc = new IMC(peso.ValorKg, this.AlturaMetros);
                return imc;
            }
            return null;
        }
    }
}
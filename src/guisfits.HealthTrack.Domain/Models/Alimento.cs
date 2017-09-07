using guisfits.HealthTrack.Domain.Helpers;
using guisfits.HealthTrack.Domain.Validation.Alimento;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace guisfits.HealthTrack.Domain.Models
{
    public enum TipoAlimento
    {
        [Display(Name = "Café da Manhã")]
        CafeDaManha,
        [Display(Name = "Almoço")]
        Almoco,
        Jantar,
        Lanche,
        Fruta
    }

    public class Alimento : Entity
    {
        public string Descricao { get; set; }
        public double Calorias { get; set; }
        public DateTime DataHora { get; set; }
        public Guid UsuarioId { get; set; }
        //Para o Lazy loading do EntityFramework
        public virtual Usuario Usuario { get; set; }

        public TipoAlimento Tipo { get; set; }
        [Column("Tipo")]
        public string TipoAlimentoString
        {
            get => Tipo.ToString();
            set => Tipo = value.ParceToEnum<TipoAlimento>();
        }

        public override bool EhValido()
        {
            ValidationResult = new AlimentoEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
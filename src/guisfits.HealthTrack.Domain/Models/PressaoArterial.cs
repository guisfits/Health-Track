using System;
using guisfits.HealthTrack.Domain.Validation.PressaoArterial;

namespace guisfits.HealthTrack.Domain.Models
{
    public class PressaoArterial : Entity
    {
        public DateTime DataHora { get; set; }
        public double Sistolica { get; set; } // o maior valor
        public double Diastolica { get; set; } // o menor valor
        public Guid UsuarioId { get; set; }
        //Para o Lazy loading do EntityFramework
        public virtual Usuario Usuario { get; set; }

        private string _status;
        public string Status
        {
            get
            {
                if ((Sistolica <= 140 && Diastolica <= 90) && (Sistolica >= 120 && Diastolica >= 80))
                {
                    _status = "Normal";
                    return _status;
                }
                else if (Sistolica < 120 && Diastolica < 80)
                {
                    _status = "Abaixo do normal";
                    return _status;

                }
                else if (Sistolica > 140 && Diastolica > 90)
                {
                    _status = "Elevada";
                    return _status;
                }
                else
                {
                    _status = "ERRO";
                    return _status;
                }
            }
            protected set
            {
                if (value != null)
                    _status = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sistolica">O maior valor</param>
        /// <param name="diastolica">O menor valor</param>
        /// <param name="dataHora">Data e Hora</param>
        public PressaoArterial(double sistolica, double diastolica, DateTime dataHora)
        {
            this.DataHora = dataHora;
            this.Sistolica = sistolica;
            this.Diastolica = diastolica;
        }

        public PressaoArterial()
        {

        }

        public override bool EhValido()
        {
            ValidationResult = new PressaoArterialEstaConsistenteValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
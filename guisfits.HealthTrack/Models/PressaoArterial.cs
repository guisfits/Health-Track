using System;

namespace guisfits.HealthTrack.Models
{
    public class PressaoArterial
    {
        public DateTime DataHora { get; set; }
        public double Sistolica { get; set; } // o maior valor
        public double Diastolica { get; set; } // o menor valor

        public string Status
        {
            get
            {
                if ((Sistolica <= 140 && Diastolica <= 90) && (Sistolica >= 120 && Diastolica >= 80))
                    return "Normal";
                else if (Sistolica < 120 && Diastolica < 80)
                    return "Abaixo do normal";
                else if (Sistolica > 140 && Diastolica > 90)
                    return "Elevada";
                else
                    return "ERRO";
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
    }
}
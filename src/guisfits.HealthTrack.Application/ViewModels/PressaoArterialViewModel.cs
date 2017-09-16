using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace guisfits.HealthTrack.Application.ViewModels
{
    public class PressaoArterialViewModel : EntityViewModel
    {
        [Required(ErrorMessage = "O campo de pressão Sistólica é requirido")]
        [DisplayName("Sistólica")]
        public double Sistolica { get; set; }

        [Required(ErrorMessage = "O campo de pressão Diastólica é requirido")]
        [DisplayName("Diastólica")]
        public double Diastolica { get; set; }

        [Required(ErrorMessage = "O campo Data e Hora é requerido")]
        [DisplayName("Data e Hora")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:g}")]
        [DataType(DataType.DateTime, ErrorMessage = "Data e Hora em formato inválido")]
        public DateTime DataHora { get; set; }

        [DisplayName("Status")]
        public string Status { get; set; }

        [ScaffoldColumn(false)]
        public Guid UsuarioId { get; set; }
    }
}

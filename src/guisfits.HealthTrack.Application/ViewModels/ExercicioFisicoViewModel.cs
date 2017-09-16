using guisfits.HealthTrack.Domain.Models;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace guisfits.HealthTrack.Application.ViewModels
{
    public class ExercicioFisicoViewModel : EntityViewModel
    {
        [Required(ErrorMessage = "O campo Tipo de Exercício é requerido")]
        [DisplayName("Tipo de Exercício")]
        public TipoExercicio Tipo { get; set; }

        [MaxLength(300, ErrorMessage = "Você excedeu o tamanho máximo de caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Calorias Queimadas é requerido")]
        [DisplayName("Calorias Queimadas")]
        public double Calorias { get; set; }

        [Required(ErrorMessage = "O campo Data e Hora é requerido")]
        [DisplayName("Data e Hora")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:g}")]
        [DataType(DataType.DateTime, ErrorMessage = "Data e Hora em formato inválido")]
        public DateTime DataHora { get; set; }

        [ScaffoldColumn(false)]
        public Guid UsuarioId { get; set; }
    }
}

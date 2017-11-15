using HealthTrack.Domain.Enums;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HealthTrack.MVC.ViewModels
{
    public class ExercicioFisicoViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "O campo Tipo de Exercício é requerido")]
        [DisplayName("Tipo de Exercício")]
        public ExercicioTipo? Tipo { get; set; }

        [MaxLength(300, ErrorMessage = "Você excedeu o tamanho máximo de caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Calorias Queimadas é requerido")]
        [DisplayName("Calorias Queimadas")]
        public float? Calorias { get; set; }

        [DataType(DataType.DateTime, ErrorMessage = "Data e Hora em formato inválido")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.Time, ErrorMessage = "Hora em formato inválido")]
        public DateTime Hora { get; set; }

        [ScaffoldColumn(false)]
        public string UsuarioId { get; set; }

        public DateTime ObterDataCompleta()
        {
            return DateTime.Parse($"{Data.ToShortDateString()} {Hora.ToShortTimeString()}");
        }
    }
}

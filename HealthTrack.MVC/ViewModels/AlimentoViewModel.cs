using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using HealthTrack.Domain.Enums;

namespace HealthTrack.MVC.ViewModels
{
    public class AlimentoViewModel
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "O campo Tipo de Alimento é requerido")]
        [DisplayName("Tipo de Alimento")]
        public AlimentoTipo? Tipo { get; set; }

        [MaxLength(300, ErrorMessage = "Você excedeu o tamanho máximo de caracteres")]
        [DisplayName("Descrição")]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "O campo Calorias Ingeridas é requerido")]
        [DisplayName("Calorias Ingeridas")]
        public float? Calorias { get; set; }

        [Required(ErrorMessage = "O campo Data e Hora é requerido")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O campo {0} é requerido")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        [DataType(DataType.Time, ErrorMessage = "Hora em formato inválido")]
        public DateTime Hora { get; set; } = DateTime.Now;

        [ScaffoldColumn(false)]
        public string UsuarioId { get; set; }

        public DateTime ObterDataCompleta()
        {
            return DateTime.Parse($"{Data.ToShortDateString()} {Hora.ToShortTimeString()}");
        }
    }
}
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using HealthTrack.Domain.Enums;
using HealthTrack.Domain.Models;

namespace HealthTrack.MVC.ViewModels
{
    public abstract class DashboardViewModel
    {
        [Key]
        public string Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é requerido")]
        [MaxLength(30, ErrorMessage = "Você excedeu o tamanho máximo de caracteres")]
        [MinLength(2, ErrorMessage = "Você deve digitar mais alguns caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Sobrenome é requerido")]
        [MaxLength(300, ErrorMessage = "Você excedeu o tamanho máximo de caracteres")]
        [MinLength(2, ErrorMessage = "Você deve digitar mais alguns caracteres")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo Sexo é requerido")]
        [DisplayName("Sexo")]
        public Sexo Sexo { get; set; }

        [Required(ErrorMessage = "O campo Altura (cm) é requerido")]
        [DisplayName("Altura (cm)")]
        public float Altura { get; set; }

        [Required(ErrorMessage = "O campo Nascimento é requerido")]
        [DisplayName("Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:g}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public string Nascimento { get; set; }

        [ScaffoldColumn(false)]
        public ImcViewModel Imc { get; set; }

        public IList<Alimento> Alimentos { get; set; }
        public IList<ExercicioFisico> ExercicioFisicos { get; set; }
        public IList<Peso> Pesos { get; set; }
        public IList<PressaoArterial> PressaoArteriais { get; set; }

        public DashboardViewModel()
        {
            Alimentos = new List<Alimento>();
            ExercicioFisicos = new List<ExercicioFisico>();
            Pesos = new List<Peso>();
            PressaoArteriais = new List<PressaoArterial>();
        }
    }
}
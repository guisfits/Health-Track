using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using guisfits.HealthTrack.Domain.Models;
using System.ComponentModel;
using AutoMapper;

namespace guisfits.HealthTrack.Application.ViewModels
{
    public class UsuarioViewModel : EntityViewModel
    {
        public UsuarioViewModel()
        {
            Alimentos = new List<Alimento>();
            ExerciciosFisicos = new List<ExercicioFisico>();
            PressoesArteriais = new List<PressaoArterial>();
            Pesos = new List<Peso>();
        }

        [Required(ErrorMessage = "O campo Nome é requerido")]
        [MaxLength(300, ErrorMessage = "O tamanho máximo de caracteres é de {0}")]
        [MinLength(2, ErrorMessage = "O tamanho mínimo de caracteres é de {0}")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Sobrenome é requerido")]
        [MaxLength(300, ErrorMessage = "O tamanho máximo de caracteres é de {0}")]
        [MinLength(2, ErrorMessage = "O tamanho mínimo de caracteres é de {0}")]
        public string Sobrenome { get; set; }

        [Required(ErrorMessage = "O campo Sexo é requerido")]
        [DisplayName("Sexo")]
        public TipoSexo Sexo { get; set; }

        [Required(ErrorMessage = "O campo Altura (cm) é requerido")]
        [DisplayName("Altura (cm)")]
        public double Altura { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é requerido")]
        [DisplayName("Data de Nascimento")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date, ErrorMessage = "Data de Nascimento em formato inválido")]
        public DateTime Nascimento { get; set; }

        [Required(ErrorMessage = "O campos Peso Atual é requerido")]
        [DisplayName("Peso Atual")]
        public double PesoAtual { get; set; }

        [ScaffoldColumn(false)]
        public int IdadeAtual { get; set; }

        [ScaffoldColumn(false)]
        public string IdentityId { get; set; }

        [ScaffoldColumn(false)]
        public ImcViewModel Imc { get; set; }

        [ScaffoldColumn(false)]
        public virtual IList<Peso> Pesos { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<Alimento> Alimentos { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<ExercicioFisico> ExerciciosFisicos { get; set; }

        [ScaffoldColumn(false)]
        public virtual ICollection<PressaoArterial> PressoesArteriais { get; set; }

        public ImcViewModel GetImc(double peso, double altura)
        {
            return Mapper.Map<ImcViewModel>(new Imc(peso, altura));
        }
    }
}

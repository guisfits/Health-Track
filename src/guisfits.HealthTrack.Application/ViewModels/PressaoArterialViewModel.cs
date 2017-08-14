using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace guisfits.HealthTrack.Application.ViewModels
{
    public class PressaoArterialViewModel
    {
        [Key]
        public Guid Id { get; set; }

        public PressaoArterialViewModel()
        {
            Id = Guid.NewGuid();
        }

        [Required(ErrorMessage = "")]
        public double Sistolica { get; set; }

        public double Diastolica { get; set; }

        public DateTime DataHora { get; set; }
        
        public string Status { get; set; }

        [ScaffoldColumn(false)]
        public Guid UsuarioId { get; set; }
    }
}

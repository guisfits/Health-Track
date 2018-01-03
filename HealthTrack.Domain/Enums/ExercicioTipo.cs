using System.ComponentModel.DataAnnotations;

namespace HealthTrack.Domain.Enums
{
    public enum ExercicioTipo
    {
        Caminhada,

        Corrida,

        Pedalada,

        [Display(Name = "Musculação")]
        Musculacao
    }
}

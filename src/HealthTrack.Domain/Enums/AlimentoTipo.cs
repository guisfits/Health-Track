using System.ComponentModel.DataAnnotations;

namespace HealthTrack.Domain.Enums
{
    public enum AlimentoTipo
    {
        [Display(Name = "Café da Manhã")]
        CafeDaManha,

        [Display(Name = "Almoço")]
        Almoco,

        Jantar,

        Lanche,

        Fruta
    }
}

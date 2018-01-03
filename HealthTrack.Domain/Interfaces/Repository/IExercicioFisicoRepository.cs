using System.Collections.Generic;
using HealthTrack.Domain.Models;

namespace HealthTrack.Domain.Interfaces.Repository
{
    public interface IExercicioFisicoRepository : IRepository<ExercicioFisico>
    {
        IEnumerable<ExercicioFisico> ObterPorUsuario(string id);
    }
}

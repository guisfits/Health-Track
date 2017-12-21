using System;
using Core.Interfaces.Repository;
using HealthTrack.Domain.Interfaces.Repository;

namespace HealthTrack.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUsuarioRepository UsuarioRepository { get; }
        IAlimentoRepository AlimentoRepository { get; }
        IExercicioFisicoRepository ExercicioFisicoRepository { get; }
        IPesoRepository PesoRepository { get; }
        IPressaoArterialRepository PressaoArterialRepository { get; }

        int Commit();
    }
}

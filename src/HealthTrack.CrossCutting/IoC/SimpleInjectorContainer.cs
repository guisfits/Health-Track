using Core.Interfaces.Repository;
using HealthTrack.Data.Context;
using HealthTrack.Data.Repository;
using HealthTrack.Data.UnitOfWork;
using HealthTrack.Domain.Interfaces;
using HealthTrack.Domain.Interfaces.Repository;
using SimpleInjector;

namespace HealthTrack.CrossCutting.IoC
{
    public static class SimpleInjectorContainer
    {
        public static void Register(Container container)
        {
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IAlimentoRepository, AlimentoRepository>(Lifestyle.Scoped);
            container.Register<IPesoRepository, PesoRepository>(Lifestyle.Scoped);
            container.Register<IExercicioFisicoRepository, ExercicioFisicoRepository>(Lifestyle.Scoped);
            container.Register<IPressaoArterialRepository, PressaoArterialRepository>(Lifestyle.Scoped);
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);
            container.Register<HealthTrackContext>(Lifestyle.Scoped);
        }
    }
}

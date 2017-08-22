using guisfits.HealthTrack.Application.Interfaces;
using guisfits.HealthTrack.Application.Services;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Services;
using guisfits.HealthTrack.Infra.Data.Context;
using guisfits.HealthTrack.Infra.Data.Repository;
using SimpleInjector;

namespace guisfits.HealthTrack.CrossCutting.IoC
{
    public static class SimpleInjectorContainer
    {
        public static void Register(Container container)
        {
            //Domain
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);

            //Application
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);

            //Infra.Data
            container.Register<IUsuarioRepository, UsuarioRepository>(Lifestyle.Scoped);
            container.Register<IAlimentoRepository, AlimentoRepository>(Lifestyle.Scoped);
            container.Register<IPesoRepository, PesoRepository>(Lifestyle.Scoped);
            container.Register<IExercicioFisicoRepository, ExercicioFisicoRepository>(Lifestyle.Scoped);
            container.Register<IPressaoArterialRepository, PressaoArterialRepository>(Lifestyle.Scoped);
            container.Register<HealthTrackContext>(Lifestyle.Scoped);
        }
    }
}

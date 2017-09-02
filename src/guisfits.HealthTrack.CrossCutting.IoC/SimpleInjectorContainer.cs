﻿using guisfits.HealthTrack.Application.Interfaces;
using guisfits.HealthTrack.Application.Services;
using guisfits.HealthTrack.Domain.Interfaces.Repository;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Services;
using guisfits.HealthTrack.Infra.Data.Context;
using guisfits.HealthTrack.Infra.Data.Repository;
using guisfits.HealthTrack.Infra.Data.UoW;
using SimpleInjector;

namespace guisfits.HealthTrack.CrossCutting.IoC
{
    public static class SimpleInjectorContainer
    {
        public static void Register(Container container)
        {
            //Domain
            container.Register<IUsuarioService, UsuarioService>(Lifestyle.Scoped);
            container.Register<IAlimentoService, AlimentoService>(Lifestyle.Scoped);
            container.Register<IExercicioFisicoService, ExercicioFisicoService>(Lifestyle.Scoped);
            container.Register<IPesoService, PesoService>(Lifestyle.Scoped);
            container.Register<IPressaoArterialService, PressaoArterialService>(Lifestyle.Scoped);

            //Application
            container.Register<IUsuarioAppService, UsuarioAppService>(Lifestyle.Scoped);
            container.Register<IAlimentoAppService, AlimentoAppService>(Lifestyle.Scoped);
            container.Register<IExercicioFisicoAppService, ExercicioFisicoAppService>(Lifestyle.Scoped);
            container.Register<IPesoAppService, PesoAppService>(Lifestyle.Scoped);
            container.Register<IPressaoArterialAppService, PressaoArterialAppService>(Lifestyle.Scoped);

            //Infra.Data
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

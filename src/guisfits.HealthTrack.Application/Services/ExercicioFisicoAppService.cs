using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using guisfits.HealthTrack.Application.Interfaces;
using guisfits.HealthTrack.Application.ViewModels;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Domain.Services;
using guisfits.HealthTrack.Infra.Data.UoW;

namespace guisfits.HealthTrack.Application.Services
{
    public class ExercicioFisicoAppService : AppService,  IExercicioFisicoAppService
    {
        private readonly IExercicioFisicoService _service;

        public ExercicioFisicoAppService(IUnitOfWork uow, 
                                         IExercicioFisicoService exercicioService) 
            : base(uow)
        {
            _service = exercicioService;
        }

        public ExercicioFisicoViewModel Adicionar(ExercicioFisicoViewModel obj)
        {
            var entity = Mapper.Map<ExercicioFisico>(obj);
            var result = _service.Adicionar(entity);

            if (result.EhValido())
                Commit();

            return Mapper.Map<ExercicioFisicoViewModel>(result);
        }

        public ExercicioFisicoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<ExercicioFisicoViewModel>(_service.ObterPorId(id));
        }

        public IEnumerable<ExercicioFisicoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<ExercicioFisicoViewModel>>(_service.ObterTodos());
        }

        public IEnumerable<ExercicioFisicoViewModel> ObterPaginado(int s, int t)
        {
            return Mapper.Map<IEnumerable<ExercicioFisicoViewModel>>(_service.ObterPaginado(s, t));
        }

        public ExercicioFisicoViewModel Atualizar(ExercicioFisicoViewModel obj)
        {
            var result = _service.Atualizar(Mapper.Map<ExercicioFisico>(obj));

            if (result.EhValido())
                Commit();

            return Mapper.Map<ExercicioFisicoViewModel>(result);
        }

        public void Remover(Guid id)
        {
            _service.Remover(id);
            Commit();
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}

using System;
using System.Collections.Generic;
using AutoMapper;
using guisfits.HealthTrack.Application.Interfaces;
using guisfits.HealthTrack.Application.ViewModels;
using guisfits.HealthTrack.Domain.Interfaces.Services;
using guisfits.HealthTrack.Domain.Models;
using guisfits.HealthTrack.Infra.Data.UoW;

namespace guisfits.HealthTrack.Application.Services
{
    public class PressaoArterialAppService : AppService, IPressaoArterialAppService
    {
        private readonly IPressaoArterialService _service;

        public PressaoArterialAppService(IUnitOfWork uow, IPressaoArterialService pressaoArterialService) : base(uow)
        {
            _service = pressaoArterialService;
        }

        public PressaoArterialViewModel Adicionar(PressaoArterialViewModel obj)
        {
            var entity = Mapper.Map<PressaoArterial>(obj);
            var result = _service.Adicionar(entity);

            if (result.EhValido())
                Commit();

            return Mapper.Map<PressaoArterialViewModel>(result);
        }

        public PressaoArterialViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<PressaoArterialViewModel>(_service.ObterPorId(id));
        }

        public IEnumerable<PressaoArterialViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<PressaoArterialViewModel>>(_service.ObterTodos());
        }

        public IEnumerable<PressaoArterialViewModel> ObterPaginado(int s, int t)
        {
            return Mapper.Map<IEnumerable<PressaoArterialViewModel>>(_service.ObterPaginado(s, t));
        }

        public PressaoArterialViewModel Atualizar(PressaoArterialViewModel obj)
        {
            var result = _service.Atualizar(Mapper.Map<PressaoArterial>(obj));

            if (result.EhValido())
                Commit();

            return Mapper.Map<PressaoArterialViewModel>(result);
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
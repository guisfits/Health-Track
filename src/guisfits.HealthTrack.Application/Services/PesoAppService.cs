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
    public class PesoAppService : AppService, IPesoAppService
    {
        private readonly IPesoService _service;

        public PesoAppService(IUnitOfWork uow, IPesoService pesoService) : base(uow)
        {
            _service = pesoService;
        }

        public PesoViewModel Adicionar(PesoViewModel obj)
        {
            var entity = Mapper.Map<Peso>(obj);
            var result = _service.Adicionar(entity);

            if (result.EhValido())
                Commit();

            return Mapper.Map<PesoViewModel>(result);
        }

        public PesoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<PesoViewModel>(_service.ObterPorId(id));
        }

        public IEnumerable<PesoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<PesoViewModel>>(_service.ObterTodos());
        }

        public IEnumerable<PesoViewModel> ObterPaginado(int s, int t)
        {
            return Mapper.Map<IEnumerable<PesoViewModel>>(_service.ObterPaginado(s, t));
        }

        public PesoViewModel Atualizar(PesoViewModel obj)
        {
            var result = _service.Atualizar(Mapper.Map<Peso>(obj));

            if (result.EhValido())
                Commit();

            return Mapper.Map<PesoViewModel>(result);
        }

        public void Remover(Guid id)
        {
            _service.Remover(id);
            Commit();
        }

        public IEnumerable<PesoViewModel> ObterTodosPorUsuario(Guid id)
        {
            return Mapper.Map<IEnumerable<PesoViewModel>>(_service.ObterTodosPorUsuario(id));
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}
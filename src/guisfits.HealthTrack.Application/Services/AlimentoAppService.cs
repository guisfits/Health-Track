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
    public class AlimentoAppService : AppService, IAlimentoAppService
    {
        private readonly IAlimentoService _alimentoService;

        public AlimentoAppService(IUnitOfWork uow, 
                                  IAlimentoService alimentoService) 
            : base(uow)
        {
            _alimentoService = alimentoService;
        }

        public AlimentoViewModel Adicionar(AlimentoViewModel obj)
        {
            var alimento = Mapper.Map<Alimento>(obj);
            var result = _alimentoService.Adicionar(alimento);

            if (result.EhValido())
                Commit();

            return Mapper.Map<AlimentoViewModel>(result);
        }

        public AlimentoViewModel ObterPorId(Guid id)
        {
            return Mapper.Map<AlimentoViewModel>(_alimentoService.ObterPorId(id));
        }

        public IEnumerable<AlimentoViewModel> ObterTodos()
        {
            return Mapper.Map<IEnumerable<AlimentoViewModel>>(_alimentoService.ObterTodos());
        }

        public IEnumerable<AlimentoViewModel> ObterPaginado(int s, int t)
        {
            return Mapper.Map<IEnumerable<AlimentoViewModel>>(_alimentoService.ObterPaginado(s,t));
        }

        public AlimentoViewModel Atualizar(AlimentoViewModel obj)
        {
            var result = _alimentoService.Atualizar(Mapper.Map<Alimento>(obj));

            if (result.EhValido())
                Commit();

            return Mapper.Map<AlimentoViewModel>(result);
        }

        public void Remover(Guid id)
        {
            _alimentoService.Remover(id);
            Commit();
        }

        public void Dispose()
        {
            _alimentoService.Dispose();
        }
    }
}
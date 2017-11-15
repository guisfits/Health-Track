using AutoMapper;
using HealthTrack.Domain.Models;
using HealthTrack.MVC.ViewModels;

namespace HealthTrack.MVC.AutoMapper
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>()
                .ForMember(to => to.Imc, from =>
                {
                    from.MapFrom(x => x.GetImc());
                })
                .ForMember(to => to.PesoAtual, from =>
                {
                    from.MapFrom(x => x.PesoAtual());
                })
                .ForMember(to => to.IdadeAtual, from =>
                {
                    from.MapFrom(x => x.IdadeAtual());
                })
                .ForSourceMember(c => c.Validation, from =>
                {
                    from.Ignore();
                })
                .ReverseMap();
        }
    }
}
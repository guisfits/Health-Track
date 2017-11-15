using AutoMapper;
using HealthTrack.Domain.Models;
using HealthTrack.MVC.ViewModels;

namespace HealthTrack.MVC.AutoMapper
{
    public class PressaoArterialProfile : Profile
    {
        public PressaoArterialProfile()
        {
            CreateMap<PressaoArterialViewModel, PressaoArterial>()
                .ForSourceMember(from => from.Data, to =>
                {
                    to.Ignore();
                })
                .ForSourceMember(from => from.Hora, to =>
                {
                    to.Ignore();
                })
                .ReverseMap();

            CreateMap<PressaoArterial, PressaoArterialViewModel>()
                .ForMember(to => to.Status, from =>
                {
                    from.MapFrom(x => x.ObterStatus());
                });
        }
    }
}
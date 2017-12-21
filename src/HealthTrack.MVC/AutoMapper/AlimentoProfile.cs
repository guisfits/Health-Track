using AutoMapper;
using HealthTrack.Domain.Models;
using HealthTrack.MVC.ViewModels;

namespace HealthTrack.MVC.AutoMapper
{
    public class AlimentoProfile : Profile
    {
        public AlimentoProfile()
        {
            CreateMap<AlimentoViewModel, Alimento>()
                .ForSourceMember(from => from.Data, to =>
                {
                    to.Ignore();
                })
                .ForSourceMember(from => from.Hora, to =>
                {
                    to.Ignore();
                })
                .ReverseMap();
        }
    }
}
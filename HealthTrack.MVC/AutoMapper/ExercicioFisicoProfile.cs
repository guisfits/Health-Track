using AutoMapper;
using HealthTrack.Domain.Models;
using HealthTrack.MVC.ViewModels;

namespace HealthTrack.MVC.AutoMapper
{
    public class ExercicioFisicoProfile : Profile
    {
        public ExercicioFisicoProfile()
        {
            CreateMap<ExercicioFisicoViewModel, ExercicioFisico>()
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
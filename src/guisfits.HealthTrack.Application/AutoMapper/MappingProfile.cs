using AutoMapper;
using guisfits.HealthTrack.Application.ViewModels;
using guisfits.HealthTrack.Domain.Models;

namespace guisfits.HealthTrack.Application.AutoMapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Usuario, UsuarioViewModel>().ReverseMap();
            CreateMap<Peso, PesoViewModel>().ReverseMap();
            CreateMap<Alimento, AlimentoViewModel>().ReverseMap();
            CreateMap<ExercicioFisico, ExercicioFisicoViewModel>().ReverseMap();
            CreateMap<PressaoArterial, PressaoArterialViewModel>().ReverseMap();
            CreateMap<Imc, ImcViewModel>().ReverseMap();
            CreateMap<Entity, EntityViewModel>().ReverseMap();
        }
    }
}

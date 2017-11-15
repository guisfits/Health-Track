using AutoMapper;
using HealthTrack.Domain.Models;
using HealthTrack.MVC.ViewModels;

namespace HealthTrack.MVC.AutoMapper
{
    public class ImcProfile : Profile
    {
        public ImcProfile()
        {
            CreateMap<Imc, ImcViewModel>().ReverseMap();
        }
    }
}
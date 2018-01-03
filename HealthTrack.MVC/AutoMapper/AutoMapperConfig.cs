using AutoMapper;

namespace HealthTrack.MVC.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<UsuarioProfile>();
                x.AddProfile<AlimentoProfile>();
                x.AddProfile<ExercicioFisicoProfile>();
                x.AddProfile<PesoProfile>();
                x.AddProfile<PressaoArterialProfile>();
                x.AddProfile<ImcProfile>();
            });
        }
    }
}
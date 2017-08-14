using AutoMapper;

namespace guisfits.HealthTrack.Application.AutoMapper
{
    public class AutoMapperConfig 
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(x =>
            {
                x.AddProfile<MappingProfile>();
            });
        }
    }
}

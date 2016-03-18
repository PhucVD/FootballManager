using FootballManager.Common.Classes;
using FootballManager.Domain;

namespace FootballManager.App_Start
{
    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.Initialize(configuration =>
            {
                configuration.CreateMap<Team, TeamViewModel>()
                    .ForMember(dest => dest.NationName, opts => opts.MapFrom(src => src.Nation.NationName));

                configuration.CreateMap<Nation, NationViewModel>();
            });
        }
    }
}
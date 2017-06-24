using AutoMapper;
using FootballManager.Domain;
using FootballManager.Web.Models;

namespace FootballManager.Web.Common
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<TournamentViewModel, Tournament>().ReverseMap();

        }
      
    }
}
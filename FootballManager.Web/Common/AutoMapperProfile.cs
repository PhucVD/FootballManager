using AutoMapper;
using FootballManager.Domain;
using FootballManager.Web.Models;

namespace FootballManager.Web.Common
{
    public class AutoMapperProfile : Profile
    {
        protected override void Configure()
        {
            CreateMap<TournamentViewModel, Tournament>().ReverseMap();
        }
    }
}
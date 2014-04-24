using System.Linq;
using System.Web.UI;
using AutoMapper;
using Folferine.Website.Domain;
using Folferine.Website.Models;

namespace Folferine.Website
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(c =>
            {
                c.CreateMap<Game, GameViewModel>()
                    .ForMember(dest => dest.LastRound, opt => opt.MapFrom(source => source.GetLastRoundNumber()));

                c.CreateMap<Game, GameDetailsViewModel>();
                c.CreateMap<Scorecard, ScorecardViewModel>();
                c.CreateMap<Round, RoundViewModel>();
                c.CreateMap<Course, CourseViewModel>();
            });

            Mapper.AssertConfigurationIsValid();
        }
    }
}
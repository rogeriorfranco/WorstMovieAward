using AutoMapper;
using Worst.Movie.Award.ApplicationCore.Domain;
using Worst.Movie.Award.ApplicationCore.Domain.Response;

namespace Worst.Movie.Award.ApplicationCore.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Awards, AwardsDto>();

            CreateMap<AwardsPeriod, AwardsPeriodDto>();
        }
    }
}

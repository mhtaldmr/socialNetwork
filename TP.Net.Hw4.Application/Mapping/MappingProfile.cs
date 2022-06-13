using AutoMapper;
using TP.Net.Hw4.Application.Dtos.Requests;
using TP.Net.Hw4.Domain.Entity;

namespace TP.Net.Hw4.Application.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.Password, opt => opt.MapFrom(x => x.PasswordHash))
                .ReverseMap();

            CreateMap<UserMessageQueryDto, UserMessageQuery>();


        }
    }
}

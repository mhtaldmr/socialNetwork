using AutoMapper;
using TP.Net.Hw4.Application.Dtos.Requests;
using TP.Net.Hw4.Application.Dtos.Responses;
using TP.Net.Hw4.Domain.Entity;

namespace TP.Net.Hw4.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(x => x.Password, opt => opt.MapFrom(x => x.PasswordHash))
                .ReverseMap();

            CreateMap<UserMessage, UserMessagesResponse>()
                .ForMember(m => m.SenderName, opt => opt.MapFrom(v => v.Sender.FirstName + " " + v.Sender.LastName))
                .ForMember(m => m.ReceiverName, opt => opt.MapFrom(v => v.Receiver.FirstName + " " + v.Receiver.LastName))
                .ForMember(m => m.MessageType, opt => opt.MapFrom(v => v.MessageType.MessageTypeName));

        }
    }
}

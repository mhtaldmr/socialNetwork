using AutoMapper;
using TP.Net.Hw.Application.Dtos.Requests;
using TP.Net.Hw.Application.Dtos.Responses;
using TP.Net.Hw.Domain.Entity;

namespace TP.Net.Hw.Application.Mapping
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

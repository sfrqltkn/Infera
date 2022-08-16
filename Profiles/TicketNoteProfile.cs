using AutoMapper;
using Infera_WebApi.DTOs.TicketNote;
using Infera_WebApi.Models;
using Infera_WebApi.Requests.TicketNote;

namespace Infera_WebApi.Profiles
{
    public class TicketNoteProfile : Profile
    {
        public TicketNoteProfile()
        {
            CreateMap<TicketNote, TicketNoteReadDto>();
            CreateMap<TicketNoteReadDto, TicketNote>();
            CreateMap<TicketNotePostRequest, TicketNote>();
            CreateMap<TicketNote, TicketNotePostRequest>();
            CreateMap<TicketNote, TicketNoteUpdateRequest>();
        }
    }
}

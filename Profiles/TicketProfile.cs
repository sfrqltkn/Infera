using AutoMapper;
using Infera_WebApi.DTOs.Ticket;
using Infera_WebApi.Models;
using Infera_WebApi.Requests.Ticket;
namespace Infera_WebApi.Profiles
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            CreateMap<Ticket, TicketReadDto>();
            CreateMap<TicketReadDto, Ticket>();
            CreateMap<TicketPostRequest, Ticket>();
            CreateMap<Ticket, TicketPostRequest>();
            CreateMap<Ticket, TicketUpdateRequest>();
        }
    }
}

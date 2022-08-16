using Infera_WebApi.DTOs.Ticket;
using Infera_WebApi.Requests.Ticket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Infera_WebApi.Repositories.Ticket
{
    public interface ITicketRepository
    {
        public IEnumerable<TicketReadDto> GetAll(TicketGetAllRequest ticketGetAllRequest);
        public TicketReadDto GetById(int id);
        public TicketReadDto Post(TicketPostRequest ticketPostRequest);
        public bool Update(int Id, TicketUpdateRequest ticketUpdateRequest);
        public bool Delete(int Id);
    }
}

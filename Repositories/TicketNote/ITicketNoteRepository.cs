using Infera_WebApi.DTOs.TicketNote;
using Infera_WebApi.Requests.TicketNote;

namespace Infera_WebApi.Repositories
{
    public interface ITicketNoteRepository
    {
        public IEnumerable<TicketNoteReadDto> GetAll(TicketNoteGetAllRequest ticketNoteGetAllRequest);
        public TicketNoteReadDto GetById(int id);
        public TicketNoteReadDto Post(TicketNotePostRequest ticketNotePostRequest);
        public bool Update(int Id, TicketNoteUpdateRequest ticketNoteUpdateRequest);
        public bool Delete(int Id);
    }
}


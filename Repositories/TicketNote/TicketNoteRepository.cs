using AutoMapper;
using Infera_WebApi.Context;
using Infera_WebApi.DTOs.TicketNote;
using Infera_WebApi.Requests.TicketNote;
using Microsoft.EntityFrameworkCore;

namespace Infera_WebApi.Repositories.TicketNote
{
    public class TicketNoteRepository : ITicketNoteRepository
    {
        private readonly SqlServerDbContext _context;
        private readonly IMapper _mapper;
        public TicketNoteRepository(SqlServerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<TicketNoteReadDto> GetAll(TicketNoteGetAllRequest ticketNoteGetAllRequest)
        {
            var tickets = _context.TicketNotes.AsQueryable();

            if (ticketNoteGetAllRequest.Note != null)
                tickets = tickets.Where(t => t.Note.StartsWith(ticketNoteGetAllRequest.Note.Trim()));

            int Offset = (ticketNoteGetAllRequest.PageNumber - 1) * ticketNoteGetAllRequest.PageSize;
            int Limit = ticketNoteGetAllRequest.PageSize;

            var result = tickets.OrderBy(u => u.Id)
                .Skip(Offset > 0 ? Offset : 0)
                .Take(Limit)
                .ToList();

            return _mapper.Map<IEnumerable<TicketNoteReadDto>>(result);
        }

        public TicketNoteReadDto GetById(int id)
        {
            return _mapper.Map<TicketNoteReadDto>(_context.TicketNotes.FirstOrDefault(u => u.TicketId == id));
        }
        public TicketNoteReadDto Post(TicketNotePostRequest ticketNotePostRequest)
        {
            if (ticketNotePostRequest == null)
            {
                throw new ArgumentNullException(nameof(ticketNotePostRequest));
            }

            Models.TicketNote tickets = _mapper.Map<Models.TicketNote>(ticketNotePostRequest);
            _context.TicketNotes.Add(tickets);
            SaveChanges();
            return _mapper.Map<TicketNoteReadDto>(tickets);
        }
        public bool Update(int Id, TicketNoteUpdateRequest ticketNoteUpdateRequest)
        {
            if (ticketNoteUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(TicketNoteUpdateRequest));
                return false;
            }

            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
                return false;
            }

            Models.TicketNote ticketnotes = _context.TicketNotes.FirstOrDefault(t => t.TicketId == Id);

            if (ticketnotes == null)
            {
                throw new KeyNotFoundException(nameof(Id));
                return false;
            }

            if (ticketNoteUpdateRequest.Note != null) ticketnotes.Note = ticketNoteUpdateRequest.Note;
            if (ticketNoteUpdateRequest.TicketId != null) ticketnotes.TicketId = (int)ticketNoteUpdateRequest.TicketId;
            _context.Entry(ticketnotes).State = EntityState.Modified;
            SaveChanges();
            _mapper.Map(ticketnotes, ticketNoteUpdateRequest);
            return true;
        }
        public bool Delete(int Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
            }

            Models.TicketNote ticketNote = _context.TicketNotes.FirstOrDefault(t => t.Id == Id);
            if (ticketNote == null)
                throw new KeyNotFoundException(nameof(Id));

            _context.TicketNotes.Remove(ticketNote);
            SaveChanges();
            return true;
        }
        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}

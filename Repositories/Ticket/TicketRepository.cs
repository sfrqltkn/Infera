using AutoMapper;
using Infera_WebApi.Context;
using Infera_WebApi.DTOs.Ticket;
using Infera_WebApi.Requests.Ticket;
using Microsoft.EntityFrameworkCore;

namespace Infera_WebApi.Repositories.Ticket
{
    public class TicketRepository : ITicketRepository
    {
        private readonly SqlServerDbContext _context;
        private readonly IMapper _mapper;

        public TicketRepository(SqlServerDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public IEnumerable<TicketReadDto> GetAll(TicketGetAllRequest ticketGetAllRequest)
        {
            var tickets = _context.Tickets.AsQueryable();

            if (ticketGetAllRequest.NotiferPersonFullName != null)
                tickets = tickets.Where(t => t.NotiferPersonFullName.StartsWith(ticketGetAllRequest.NotiferPersonFullName.Trim()));

            if (ticketGetAllRequest.Description != null)
                tickets = tickets.Where(t => t.Description.StartsWith(ticketGetAllRequest.Description.Trim()));
            ticketGetAllRequest.TotalRecords = tickets.Count();

            int Offset = (ticketGetAllRequest.PageNumber - 1) * ticketGetAllRequest.PageSize;
            int Limit = ticketGetAllRequest.PageSize;

            var result = tickets.OrderBy(u => u.Id)
                .Skip(Offset > 0 ? Offset : 0)
                .Take(Limit)
                .ToList();

            return _mapper.Map<IEnumerable<TicketReadDto>>(result);
        }

        public TicketReadDto GetById(int Id)
        {
            return _mapper.Map<TicketReadDto>(_context.Tickets.FirstOrDefault(u => u.Id == Id));
        }

        public TicketReadDto Post(TicketPostRequest ticketPostRequest)
        {
            if (ticketPostRequest == null)
            {
                throw new ArgumentNullException(nameof(ticketPostRequest));
            }

            Models.Ticket tickets = _mapper.Map<Models.Ticket>(ticketPostRequest);
            _context.Tickets.Add(tickets);
            SaveChanges();
            return _mapper.Map<TicketReadDto>(tickets);
        }
        public bool Delete(int Id)
        {
            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
            }
            Models.Ticket ticket = _context.Tickets.Where(u => u.Id == Id).Include(x => x.TicketNotes).FirstOrDefault();
            if (ticket == null)
                throw new KeyNotFoundException(nameof(Id));

            _context.Tickets.Remove(ticket);
            SaveChanges();
            return true;
        }
        public bool Update(int Id, TicketUpdateRequest ticketUpdateRequest)
        {
            if (ticketUpdateRequest == null)
            {
                throw new ArgumentNullException(nameof(TicketUpdateRequest));
                return false;
            }

            if (Id == null)
            {
                throw new ArgumentNullException(nameof(Id));
                return false;
            }

            Models.Ticket ticket = _context.Tickets.FirstOrDefault(t => t.Id == Id);

            if (ticket == null)
            {
                throw new KeyNotFoundException(nameof(Id));
                return false;
            }

            if (ticketUpdateRequest.NotiferPersonFullName != null) ticket.NotiferPersonFullName = ticketUpdateRequest.NotiferPersonFullName;
            if (ticketUpdateRequest.Description != null) ticket.Description = ticketUpdateRequest.Description;
            _context.Entry(ticket).State = EntityState.Modified;
            SaveChanges();
            _mapper.Map(ticket, ticketUpdateRequest);
            return true;
        }
        private bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
